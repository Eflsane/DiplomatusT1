using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMonoColorBarChartQuizTime : MonoBehaviour
{
    [SerializeField]
    private PiePart piePart;

    private List<UserQuizStats> userQuizStats;

    private void Start()
    {

    }

    public void GetData(List<UserQuizStats> userQuizStats)
    {
        this.userQuizStats = userQuizStats;
        GenerateMonoColorBarChartValues();
    }

    /*public void GetAllUsers(List<UsersWithout> usersWithout)
    {
        this.users = usersWithout;
    }

    public void GetAllGenders(List<Genders> genders)
    {
        this.genders = genders;

        GenerateMonoColorBarChartValues(genders[0]);
    }*/

    public void GenerateMonoColorBarChartValues()
    {
        SortedDictionary<long, float> charts = new SortedDictionary<long, float>();

        for (int i = 0; i < 10; i++)
        {
            charts.Add(i, 0);
        }

        for (int i = 0; i < userQuizStats.Count; i++)
        {
            double days = 0;
            days = (DateTime.Now - userQuizStats[i].EndTime).Days;
            if (days < 10)
            {
                charts[(long)(10 - 1 - days)] += (float)(userQuizStats[i].EndTime - userQuizStats[i].BeginTime).TotalSeconds;
            }
        }

        string[] agenda = new string[charts.Count];
        /*for (int i = 0; i < agenda.Length; i++)
        {
            agenda[i] = Enum.GetName(typeof(AgeTypes), i + 1);
        }*/

        foreach (var item in charts)
        {
            agenda[item.Key] = Enum.GetName(typeof(AgeTypes), item.Key + 1);
        }

        var monoColorBarCart = GetComponentInParent<MonoColorBarChart>();
        monoColorBarCart.DisplayNewValues(charts,
            monoColorBarCart.ImageMonoColorBarParts,
            agenda);
        //GetComponent<PiePartContainer>().GeneratePieChartParts(charts);
    }
}
