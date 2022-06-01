using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBasicController : MonoBehaviour
{
    public static CallBasicController Instance { get; private set; }

    public event Action<List<Minigames>> OnDataMinigamesGetted = (List<Minigames> minigames) => { };
    public event Action<List<UsersWithout>> OnDataUsersGetted = (List<UsersWithout> usersWithout) => { };
    public event Action<List<UserMinigameStats>> OnDataUserMinigameStatsGetted = (List<UserMinigameStats> userMinigameStats) => { };

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);
    }

    private void Start()
    {
        //GetData();
    }

    public void GetData()
    {
        MinigamesDTO.Instance.OnGetAllMinigamesSuccess += GetAllMinigames;
        UsersWithoutDTO.Instance.OnGetAllUsersSuccess += GetAllUsers;
        UserMinigameStatsDTO.Instance.OnGetAllUserMinigameStatsSuccess += GetAllUserMinigameStats;

        MinigamesDTO.Instance.GetAllMinigames();
    }

    public void GetAllMinigames(List<Minigames> minigames)
    {
        OnDataMinigamesGetted?.Invoke(minigames);

        MinigamesDTO.Instance.OnGetAllMinigamesSuccess -= GetAllMinigames;

        UsersWithoutDTO.Instance.GetAllUsers();
    }

    public void GetAllUsers(List<UsersWithout> usersWithout)
    {
        OnDataUsersGetted?.Invoke(usersWithout);

        UsersWithoutDTO.Instance.OnGetAllUsersSuccess -= GetAllUsers;

        UserMinigameStatsDTO.Instance.GetAllUserMinigameStats();
    }

    public void GetAllUserMinigameStats(List<UserMinigameStats> userMinigameStats)
    {
        OnDataUserMinigameStatsGetted?.Invoke(userMinigameStats);

        UserMinigameStatsDTO.Instance.OnGetAllUserMinigameStatsSuccess -= GetAllUserMinigameStats;
    }
}
