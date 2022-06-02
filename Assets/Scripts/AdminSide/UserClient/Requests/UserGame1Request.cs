using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserGame1Request : MonoBehaviour
{
    [SerializeField]
    private List<Image> avatars;
    [SerializeField]
    private string username;

    [SerializeField]
    private Text usernameText;
    [SerializeField]
    private Text coinzText;

    private GoBack manager;
    private GameManager gameManager;


    public double coinz;
    
    public string Username { get => username; private set => username = value; }

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
        gameManager = GetComponentInParent<GameManager>();
        Username = PlayerPrefs.GetString(manager.prefUserName);

        gameManager.OnGameOverApeared += UpdateCoinz;

        UsersWithoutDTO.Instance.GetUser(Username);
        UsersWithoutDTO.Instance.OnGetUserSuccess += FinishGettingData;
        UsersWithoutDTO.Instance.OnGUpdateCoinzSuccess += FinishUpdatingCoins;
        //MinigamesDTO.Instance.OnGetAllMinigamesSuccess += FinishGettingMinigamesData;

    }

    private void FinishGettingData(UsersWithout user)
    {
        coinz = user.Coinz;
    }

    private void UpdateCoinz(double coinz, double score, DateTime beginDate)
    {
        UsersWithoutDTO.Instance.UpdateUserCoinz(new UsersWithout()
        {
            Username = username,
            Coinz = coinz + this.coinz,
        });

        UserMinigameStatsDTO.Instance.AddUserMinigameStats(new UserMinigameStats()
        {
            Username = username,
            MinigameId = 1,
            UserScore = score,
            BeginTime = beginDate,
            EndTime = DateTime.Now,
            
        });
    }

    private void FinishUpdatingCoins()
    {

    }
}
