using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CallBarChartAgeSex : MonoBehaviour
{
    private List<UsersWithout> users;

    public string dataURL = string.Empty;
    public string paramsURL = string.Empty;

    public event Action OnDataGeted;
    public event Action OnParamsGeted;

    private void Start()
    {

    }

    public void GenerateBarChartValues(List<UsersWithout> usersWithout, Genders gender)
    {
        users = usersWithout;
        SortedDictionary<long, float> charts = new SortedDictionary<long, float>();

        for (int i = 1; i < 7; i++)
        {
            charts.Add(i - 1, 0);
        }

        foreach (var user in users)
        {
            if(user.Gender == gender.Id)
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

        foreach(var item in charts)
        {
            switch (Enum.GetName(typeof(AgeTypes), item.Key + 1))
            {
                case "from0To3":
                    agenda[item.Key] = "от 0 до 3";
                    break;
                case "from4To7":
                    agenda[item.Key] = "от 4 до 7";
                    break;
                case "from8To12":
                    agenda[item.Key] = "от 8 до 12";
                    break;
                case "from13To16":
                    agenda[item.Key] = "от 13 до 16";
                    break;
                case "from17To18":
                    agenda[item.Key] = "от 17 до 18";
                    break;
                case "from19To":
                    agenda[item.Key] = "старше 19";
                    break;
            }
            //agenda[item.Key] = Enum.GetName(typeof(AgeTypes), item.Key + 1);
        }

        var barCart = GetComponentInParent<BarChart>();
        barCart.DisplayNewValues(charts,
            barCart.ImageBarParts,
            agenda);
        //GetComponent<PiePartContainer>().GeneratePieChartParts(charts);
    }
}
