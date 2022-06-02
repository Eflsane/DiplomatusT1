using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UserGameLobbyRequest : MonoBehaviour
{
    [SerializeField]
    private List<Image> avatars;
    [SerializeField]
    private List<GameObject> closedMinigames;
    private List<GameObject> opennedMinigames;
    private string username;

    [SerializeField]
    private Text usernameText;
    [SerializeField]
    private Text coinzText;

    private GoBack manager;

    List<UserMinigameStats> userPlayedMinigames;
    List<Minigames> minigames;


    public double coinz;

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

        UserMinigameStatsDTO.Instance.OnGetUserMinigameStatsByUserSuccess += FinishGEttingUserminigamesData;
        MinigamesDTO.Instance.OnGetAllMinigamesSuccess += FinishGettingMinigamesData;

    }

    private void FinishGettingData(UsersWithout user)
    {
        avatars[(int)(user.AvatarID - 1)].gameObject.SetActive(true);
        usernameText.text = user.Username;
        coinzText.text = user.Coinz.ToString();
        coinz = user.Coinz;

        UserMinigameStatsDTO.Instance.GetUserMinigameStatsByUser(username);
    }

    private void FinishGEttingUserminigamesData(List<UserMinigameStats> userMinigameStats)
    {
        userPlayedMinigames = userMinigameStats.GroupBy(x => x.MinigameId).Select(grp => grp.First()).ToList();

        MinigamesDTO.Instance.GetAllMinigames();
    }

    private void FinishGettingMinigamesData(List<Minigames> minigames)
    {
        this.minigames = minigames;

        OpenOwnedMinigames();
    }

    private void OpenOwnedMinigames()
    {
        
    }
}
