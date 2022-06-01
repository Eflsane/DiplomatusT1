using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Legend : MonoBehaviour
{
    LegendPart legendPart;
    public int LegendPartsCount { get => transform.childCount; }

    // Start is called before the first frame update
    void Awake()
    {
        legendPart = GetComponentInParent<ICharts>().LegendPart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateLegendParts(SortedDictionary<long, float> charts, Image[] imagePieParts, string[] agendaString)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        LegendPart[] legendParts = new LegendPart[charts.Count];

        for (int i = 0; i < legendParts.Length; i++)
        {
            legendParts[i] = Instantiate(legendPart, this.transform, false);
            legendParts[i].Color = imagePieParts[i].color;
            legendParts[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text =
                $"{agendaString[i]}: " +
                $"{charts[i]} ({(charts[i] / GetComponentInParent<ICharts>().FindSum() * 100).ToString("0")}%)";
        }

        //Genders genders[] = CallPieChartSex.Genders
    }
}
