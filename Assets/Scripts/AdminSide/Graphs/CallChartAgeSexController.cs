using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallChartAgeSexController : MonoBehaviour
{
    public static CallChartAgeSexController Instance { get; private set; }

    public event Action<List<UsersWithout>> OnDataUsersGetted = (List<UsersWithout> usersWithout) => { };
    public event Action<List<Genders>> OnDataGendersGetted = (List<Genders> genders) => { };

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
    }
}
