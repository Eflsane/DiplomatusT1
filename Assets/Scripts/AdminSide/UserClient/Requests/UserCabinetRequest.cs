using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UserCabinetRequest : MonoBehaviour
{
    [SerializeField]
    private List<Image> avatars;
    private string username;

    private GoBack manager;

    [SerializeField]
    private Text usernameText;
    [SerializeField]
    private Text coinzText;
    [SerializeField]
    private Text emailText;
    [SerializeField]
    private Text sexText;
    [SerializeField]
    private Text birthDateText;
    [SerializeField]
    private Text registerDateText;

    [SerializeField]
    private Text highScoreText;
    [SerializeField]
    private Text midSCoreText;
    [SerializeField]
    private Text midTimeText;
    [SerializeField]
    private Text timesPlayedText;

    long minigameID = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartGettingData();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartGettingData()
    {
        manager = GetComponentInParent<GoBack>();
        username = PlayerPrefs.GetString(manager.prefUserName);

        UsersWithoutDTO.Instance.OnGetUserSuccess += FinishGettingData;
        UsersWithoutDTO.Instance.GetUser(username);

        GendersDTO.Instance.OnGetGenderSuccess += FinishGettingGender;
        UserMinigameStatsDTO.Instance.OnGetUserMinigameStatsByUserMinigameSuccess += FinishGettingStats; 
    }

    private void FinishGettingData(UsersWithout user)
    {
        UsersWithoutDTO.Instance.OnGetUserSuccess -= FinishGettingData;

        avatars[(int)(user.AvatarID) - 1].gameObject.SetActive(true);
        usernameText.text = user.Username;
        coinzText.text = user.Coinz.ToString();
        emailText.text = user.Email;
        birthDateText.text = user.DateOfBirth.ToShortDateString();
        registerDateText.text = user.RegisterDate.ToShortDateString();

        GendersDTO.Instance.GetGender(user.Gender);
        UserMinigameStatsDTO.Instance.GetUserMinigameStatsByUserMinigame(username, minigameID);
    }

    private void FinishGettingGender(Genders gender)
    {
        GendersDTO.Instance.OnGetGenderSuccess -= FinishGettingGender;
        sexText.text = gender.Gender.ToString();
    }

    private void FinishGettingStats(List<UserMinigameStats> minigameStats)
    {
        timesPlayedText.text = minigameStats.Count.ToString();
        highScoreText.text = minigameStats.Max(x => x.UserScore).ToString();

        float midTime = 0;
        float midScore = 0;
        foreach (UserMinigameStats minigameStat in minigameStats)
        {
            midScore += (float)minigameStat.UserScore;
            midTime += (float)(minigameStat.EndTime - minigameStat.BeginTime).TotalSeconds;
        }
        midScore = (float)midScore / minigameStats.Count;
        midTime = (float)midTime / minigameStats.Count;

        midSCoreText.text = midScore.ToString("0");
        midTimeText.text = $"{Mathf.FloorToInt(midTime / 60).ToString("0")}:{Mathf.FloorToInt(midTime % 60).ToString("0")}"; ;

        UserMinigameStatsDTO.Instance.OnGetUserMinigameStatsByUserMinigameSuccess -= FinishGettingStats;
    }
}
