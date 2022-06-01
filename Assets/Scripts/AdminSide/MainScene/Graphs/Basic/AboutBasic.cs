using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class AboutBasic : MonoBehaviour
{
    [SerializeField]
    private List<TMPro.TextMeshProUGUI> paramsList = new List<TMPro.TextMeshProUGUI>();
    [SerializeField]
    private MonoColorBarChart activeChart;
    [SerializeField]
    private MonoColorBarChart newChart;

    private List<Minigames> minigames;
    private List<UsersWithout> usersWithout;
    private List<UserMinigameStats> minigamesStats;

    private int selectedMinigameIndex = -1;

    public List<TextMeshProUGUI> ParamsList { get => paramsList; private set => paramsList = value; }
    public List<UsersWithout> UsersWithout { get => usersWithout; private set => usersWithout = value; }
    public List<Minigames> Minigames { get => minigames; private set => minigames = value; }
    public List<UserMinigameStats> MinigamesStats { get => minigamesStats; private set => minigamesStats = value; }

    // Start is called before the first frame update
    void Start()
    {
        LoadBasic();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GetAllMinigames(List<Minigames> minigames)
    {
        this.Minigames = minigames;
    }

    private void GetAllUsers(List<UsersWithout> usersWithout)
    {
        this.UsersWithout = usersWithout;
    }

    private void GetAllUserMinigameStats(List<UserMinigameStats> minigameStats)
    {
        this.MinigamesStats = minigameStats;

        SetBasicData();
        int y = (DateTime.Now - usersWithout[0].LastLoginDate).Days;
        List<UsersWithout> u = usersWithout.Where(x => (DateTime.Now - x.LastLoginDate).Days < 10).ToList();
        activeChart.GetComponentInChildren<CallMonoColorBarChartBasicActiveUsers>().GetData(usersWithout.Where(x => (DateTime.Now - x.LastLoginDate).Days < 10).ToList());
        newChart.GetComponentInChildren<CallMonoColorBarChartBasicNewUsers>().GetData(usersWithout.Where(x => (DateTime.Now - x.RegisterDate).Days < 10).ToList());
    }

    private void SetBasicData()
    {
        ParamsList[0].text = UsersWithout.Count.ToString();
        ParamsList[1].text = UsersWithout.
            Where(x => (System.DateTime.Now - x.RegisterDate).Days < 10).Count().ToString();
        ParamsList[2].text = UsersWithout.
            Where(x => (System.DateTime.Now - x.LastLoginDate ).Days < 10).Count().ToString();
        ParamsList[3].text = UsersWithout.
            Where(x => (System.DateTime.Now - x.LastLoginDate).Days < 1).Count().ToString();
    }

    public void LoadBasic()
    {
        CallBasicController.Instance.OnDataMinigamesGetted += GetAllMinigames;
        CallBasicController.Instance.OnDataUsersGetted += GetAllUsers;
        CallBasicController.Instance.OnDataUserMinigameStatsGetted += GetAllUserMinigameStats;
    }
}
