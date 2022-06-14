using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMinigameController : MonoBehaviour
{
    public static CallMinigameController Instance { get; private set; }

    public event Action<List<Minigames>> OnDataMinigamesGetted = (List<Minigames> minigames) => { };
    public event Action<List<UsersWithout>> OnDataUsersGetted = (List<UsersWithout> usersWithout) => { };
    public event Action<List<Genders>> OnDataGendersGetted = (List<Genders> genders) => { };  
    public event Action<List<UserMinigameStats>> OnDataUserMinigameStatsByMinigameGetted = (List<UserMinigameStats> userMinigameStats) => { };
    public event Action OnDataMinigamesUpdated = () => { };

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);
    }

    private void Start()
    {
        GetData();
    }

    public void GetData()
    {
        MinigamesDTO.Instance.OnGetAllMinigamesSuccess += GetAllMinigames;   

        MinigamesDTO.Instance.GetAllMinigames();
    }

    public void GetAllMinigames(List<Minigames> minigames)
    {
        OnDataMinigamesGetted?.Invoke(minigames);

        MinigamesDTO.Instance.OnGetAllMinigamesSuccess -= GetAllMinigames;
    }

    public void GetAllUsers(List<UsersWithout> usersWithout)
    {
        OnDataUsersGetted?.Invoke(usersWithout);

        UsersWithoutDTO.Instance.OnGetAllUsersSuccess -= GetAllUsers;

        GendersDTO.Instance.OnGetAllGendersSuccess += GetAllGenders;
        GendersDTO.Instance.GetAllGenders();
    }

    public void GetAllGenders(List<Genders> genders)
    {
        OnDataGendersGetted?.Invoke(genders);

        GendersDTO.Instance.OnGetAllGendersSuccess -= GetAllGenders;
    }

    public void GetUserMinigameStatsByMinigameData(long id)
    {
        UserMinigameStatsDTO.Instance.OnGetUserMinigameStatsByMinigameSuccess += GetUserMinigameStatsByMinigame;

        UserMinigameStatsDTO.Instance.GetUserMinigameStatsByMinigame(id);
    }

    public void GetUserMinigameStatsByMinigame(List<UserMinigameStats> userMinigameStats)
    {
        OnDataUserMinigameStatsByMinigameGetted?.Invoke(userMinigameStats);

        UserMinigameStatsDTO.Instance.OnGetUserMinigameStatsByMinigameSuccess -= GetUserMinigameStatsByMinigame;

        UsersWithoutDTO.Instance.OnGetAllUsersSuccess += GetAllUsers;
        UsersWithoutDTO.Instance.GetAllUsers();
    }

    public void UpdateMinigamesData(Minigames minigame)
    {
        MinigamesDTO.Instance.OnUpdateMinigameSuccess += UpdateMinigames;

        MinigamesDTO.Instance.UpdateMinigame(minigame);
    }

    public void UpdateMinigames()
    {
        OnDataMinigamesUpdated?.Invoke();

        MinigamesDTO.Instance.OnUpdateMinigameSuccess -= UpdateMinigames;
    }
}
