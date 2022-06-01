using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMonoColorBarChart : MonoBehaviour
{
    [SerializeField]
    private PiePart piePart;

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
        CallChartAgeSexController.Instance.OnDataUsersGetted += GetAllUsers;
        CallChartAgeSexController.Instance.OnDataGendersGetted += GetAllGenders;
    }

    public void GetAllUsers(List<UsersWithout> usersWithout)
    {
        this.users = usersWithout;
    }

    public void GetAllGenders(List<Genders> genders)
    {
        this.genders = genders;

        GenerateMonoColorBarChartValues(genders[0]);
    }

    public void GenerateMonoColorBarChartValues(Genders gender)
    {
        SortedDictionary<long, float> charts = new SortedDictionary<long, float>();

        for (int i = 1; i < 7; i++)
        {
            charts.Add(i - 1, 0);
        }

        foreach (var user in users)
        {
            if (user.Gender == gender.Id)
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
