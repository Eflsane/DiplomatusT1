﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CallPieChartAge : MonoBehaviour
{
    [SerializeField]
    private PiePart piePart;

    private List<UsersWithout> users;

    public string dataURL = string.Empty;
    public string paramsURL = string.Empty;

    public event Action OnDataGeted;
    public event Action OnParamsGeted;

    private void Start()
    {
        /*OnDataGeted += GetParams;
        OnParamsGeted += GeneratePieChartValues;*/

        GetData();
    }

    public void GetData()
    {
        CallChartAgeSexController.Instance.OnDataUsersGetted += GetAllUsers;
    }

    public void GetAllUsers(List<UsersWithout> usersWithout)
    {
        this.users = usersWithout;

        UsersWithoutDTO.Instance.OnGetAllUsersSuccess -= GetAllUsers;

        GeneratePieChartValues();
    }

    public void GeneratePieChartValues()
    {
        SortedDictionary<long, float> charts = new SortedDictionary<long, float>();

        for(int i = 1; i < 7; i++)
        {
            charts.Add(i - 1, 0); 
        }

        foreach (var user in users)
        {
            int age = (DateTime.Now.Year - user.DateOfBirth.Year);
            if (age >= 0 && age < 4)
                charts[(int)AgeTypes.from0To3 - 1] += 1;
            else if (age >= 4 && age < 7)
                charts[(int)AgeTypes.from4To7 - 1] += 1;
            else if (age >= 8 && age < 12)
                charts[(int)AgeTypes.from8To12 - 1] += 1;
            else if (age >= 13 && age < 16)
                charts[(int)AgeTypes.from13To16 - 1] += 1;
            else if (age >= 17 && age < 18)
                charts[(int)AgeTypes.from17To18 - 1] += 1;
            else if (age >= 19)
                charts[(int)AgeTypes.from19To - 1] += 1;
        }

        string[] agenda = new string[charts.Count];
        for (int i = 0; i < agenda.Length; i++)
        {
            agenda[i] = Enum.GetName(typeof(AgeTypes), i + 1);
        }

        var pieChart = GetComponentInParent<PieChart>();
        pieChart.DisplayNewValues(charts, pieChart.ImagePieParts, agenda);
        //GetComponent<PiePartContainer>().GeneratePieChartParts(charts);
    }
}
