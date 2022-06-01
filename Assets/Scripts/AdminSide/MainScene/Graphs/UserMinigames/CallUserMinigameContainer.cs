using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallUserMinigameContainer : MonoBehaviour
{
    private List<UsersWithout> usersWithout;
    private List<Genders> genders;
    private List<Minigames> minigames;
    private List<UserMinigameStats> minigamesStatsByUsers;

    public List<UsersWithout> Users { get => usersWithout; private set => usersWithout = value; }
    public List<Genders> Genders { get => genders; private set => genders = value; }
    public List<Minigames> Minigames { get => minigames; set => minigames = value; }



    // Start is called before the first frame update
    void Start()
    {
        
    }

     public void GetData()
    {
        CallUserController.Instance.OnDataUsersGetted += GetAllUsers;
        CallUserController.Instance.OnDataGendersGetted += GetAllGenders;
        CallUserController.Instance.OnDataMinigamesGetted += GetAllMinigames;
    }

    public void GetAllUsers(List<UsersWithout> usersWithout)
    {
        this.usersWithout = usersWithout;

        UsersWithoutDTO.Instance.OnGetAllUsersSuccess -= GetAllUsers;

        //GeneratePieChartValues();
    }

    public void GetAllGenders(List<Genders> genders)
    {
        this.genders = genders;

        //GeneratePieChartValues();
    }

    public void GetAllMinigames(List<Minigames> minigames)
    {
        this.minigames = minigames;

        //GeneratePieChartValues();
    }

    public void GetUsersMinigames(string username)
    {
        CallUserController.Instance.OnDataUserMinigameStatsByUserGetted += GetUsersMinigames;
        CallUserController.Instance.GetUserMinigameStatsByUserData(username);
    }

    public void GetUsersMinigames(List<UserMinigameStats> userMinigameStats)
    {
        this.minigamesStatsByUsers = userMinigameStats;
        CallUserController.Instance.OnDataUserMinigameStatsByUserGetted -= GetUsersMinigames;

        //GeneratePieChartValues();
    }

    public UsersWithout GetSelectedUser(int index)
    {

        return usersWithout[index];
    }
}
