using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BarChart : MonoBehaviour, ICharts
{
    [SerializeField]
    private BarPart barPart;
    [SerializeField]
    private LegendPart legendPart;
    [SerializeField]
    private int numBarParts;
    [SerializeField]
    private Image[] imageBarParts;
    [SerializeField]
    private SortedDictionary<long, float> valBarParts;
    private string[] agendaString;

    public BarPart BarPart { get => barPart; }

    public LegendPart LegendPart { get => legendPart; }

    public int NumBarParts
    {
        get
        {
            return numBarParts;
        }
        set
        {
            numBarParts = value;
            agendaString = new string[numBarParts];
            imageBarParts = new Image[numBarParts];
            //valBarParts = new float[numPieParts];
            valBarParts = new SortedDictionary<long, float>();
        }
    }
    public SortedDictionary<long, float> ValBarParts
    {
        get => valBarParts;
        private set
        {
            foreach (var item in value)
            {
                valBarParts.Add(item.Key, item.Value);
            }

        }
    }
    public Image[] ImageBarParts
    {
        get => imageBarParts;
        private set
        {
            for (int i = 0; i < value.Length; i++)
            {
                imageBarParts[i] = value[i];
            }

        }
    }

    public string[] AgendaString
    {
        get => agendaString;
        set
        {
            for (int i = 0; i < value.Length; i++)
            {
                agendaString[i] = value[i];
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //SetValues(valPieParts);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float FindSum()
    {
        float sum = 0;
        foreach (var value in valBarParts)
        {
            sum += value.Value;
        }
        return sum;
    }

    public void DisplayNewValues(SortedDictionary<long, float> barValues, Image[] imageBarParts, string[] agendaString)
    {
        SetValues
        (
            barValues,
            GetComponentInChildren<BarPartContainer>().GenerateBarChartParts(barValues),
            agendaString
        );

        GetComponentInChildren<Legend>().GenerateLegendParts(barValues, ImageBarParts, AgendaString);

        CalcualteFillAmount();
    }

    public void SetValues(SortedDictionary<long, float> barValues, Image[] imageBarParts, string[] agendaString)
    {
        ValBarParts = barValues;
        ImageBarParts = imageBarParts;
        AgendaString = agendaString;
    }

    public void CalcualteFillAmount()
    {
        float totalValues = 0;
        float sum = FindSum();
        totalValues = 1; //max value

        int i = 0;
        foreach (var value in valBarParts)
        {
            ImageBarParts[i].fillAmount = FindPercentage(sum, value.Key, valBarParts);
            i++;
            Debug.Log("s - " + value.Value);
        }
        /* for (int i = 0; i < pieValues.Length; i++)
         {
             totalValues += FindPercentage(sum, i, pieValues);
             imagePieParts[i].fillAmount = totalValues;
         }*/
    }




    public float FindPercentage(float sum, long index, SortedDictionary<long, float> pieValues)
    {
        float max = pieValues.Max(x => x.Value);
        return pieValues[index] / max;
        //return pieValues[index] / sum;
    }
}
