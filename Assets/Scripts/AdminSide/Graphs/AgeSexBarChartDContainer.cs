using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeSexBarChartDContainer : MonoBehaviour
{
    [SerializeField]
    private BarChart barChart;

    private List<UsersWithout> users;
    private List<Genders> genders;

    public string dataURL = string.Empty;
    public string paramsURL = string.Empty;

    public event Action OnDataGeted;
    public event Action OnParamsGeted;

    private void Start()
    {
        GetData();
    } 

    public void GetData()
    {
        CallChartAgeSexController.Instance.OnDataGendersGetted += GetAllGenders;
        CallChartAgeSexController.Instance.OnDataUsersGetted += GetAllUsers;
    }

    public void GetAllUsers(List<UsersWithout> usersWithout)
    {
        this.users = usersWithout;
    }

    public void GetAllGenders(List<Genders> genders)
    {
        this.genders = genders;

        GeneratePieChartValues();
    }

    public void GeneratePieChartValues()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        for(int i = 0; i < genders.Count; i++)
        {
            var ld = Instantiate(barChart, this.transform, false);
            ld.GetComponentsInChildren<TMPro.TextMeshProUGUI>()[1].text = genders[i].Gender.Contains("Female") ? "Женский" : "Мужской";
            ld.GetComponentInChildren<CallBarChartAgeSex>().GenerateBarChartValues(users, genders[i]);
        }
    }
}
