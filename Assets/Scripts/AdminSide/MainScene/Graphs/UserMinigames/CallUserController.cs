using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallUserController : MonoBehaviour
{
    public static CallUserController Instance { get; private set; }

    public event Action<List<UsersWithout>> OnDataUsersGetted = (List<UsersWithout> usersWithout) => { };
    public event Action<List<Genders>> OnDataGendersGetted = (List<Genders> genders) => { };
    public event Action<List<Minigames>> OnDataMinigamesGetted = (List<Minigames>  minigames) => { };
    public event Action<List<UserMinigameStats>> OnDataUserMinigameStatsByUserGetted = (List<UserMinigameStats> userMinigameStats) => { };
    public event Action<List<UserMinigameStats>> OnDataUserMinigameStatsByUserMinigameGetted = (List<UserMinigameStats> userMinigameStats) => { };

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
        UsersWithoutDTO.Instance.OnGetAllUsersSuccess += GetAllUsers;
        GendersDTO.Instance.OnGetAllGendersSuccess += GetAllGenders;
        MinigamesDTO.Instance.OnGetAllMinigamesSuccess += GetAllMinigames;

        UsersWithoutDTO.Instance.GetAllUsers();
    }

    public void GetAllUsers(List<UsersWithout> usersWithout)
    {
        OnDataUsersGetted?.Invoke(usersWithout);

        UsersWithoutDTO.Instance.OnGetAllUsersSuccess -= GetAllUsers;

        GendersDTO.Instance.GetAllGenders();
    }

    public void GetAllGenders(List<Genders> genders)
    {
        OnDataGendersGetted?.Invoke(genders);

        GendersDTO.Instance.OnGetAllGendersSuccess -= GetAllGenders;

        MinigamesDTO.Instance.GetAllMinigames();
    }

    public void GetAllMinigames(List<Minigames> minigames)
    {
        OnDataMinigamesGetted?.Invoke(minigames);

        MinigamesDTO.Instance.OnGetAllMinigamesSuccess -= GetAllMinigames;
    }

    public void GetUserMinigameStatsByUserData(string username)
    {
        UserMinigameStatsDTO.Instance.OnGetUserMinigameStatsByUserSuccess += GetUserMinigameStatsByUser;

        UserMinigameStatsDTO.Instance.GetUserMinigameStatsByUser(username);
    }

    public void GetUserMinigameStatsByUser(List<UserMinigameStats> userMinigameStats)
    {
        OnDataUserMinigameStatsByUserGetted?.Invoke(userMinigameStats);

        UserMinigameStatsDTO.Instance.OnGetUserMinigameStatsByUserSuccess -= GetUserMinigameStatsByUser;
    }

    public void GetUserMinigameStatsByUserMinigameData(string username, long id)
    {
        UserMinigameStatsDTO.Instance.OnGetUserMinigameStatsByUserMinigameSuccess += GetUserMinigameStatsByUserMinigame;

        UserMinigameStatsDTO.Instance.GetUserMinigameStatsByUserMinigame(username, id);
    }

    public void GetUserMinigameStatsByUserMinigame(List<UserMinigameStats> userMinigameStats)
    {
        OnDataUserMinigameStatsByUserMinigameGetted?.Invoke(userMinigameStats);

        UserMinigameStatsDTO.Instance.OnGetUserMinigameStatsByUserMinigameSuccess -= GetUserMinigameStatsByUserMinigame;
    }
}
