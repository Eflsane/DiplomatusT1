using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PieChart : MonoBehaviour, ICharts
{
    [SerializeField]
    private PiePart piePart;
    [SerializeField]
    private LegendPart legendPart;
    [SerializeField]
    private int numPieParts;
    [SerializeField]
    private Image[] imagePieParts;
    [SerializeField]
    private SortedDictionary<long, float>  valPieParts;
    private string[] agendaString;

    public PiePart PiePart { get => piePart;}

    public LegendPart LegendPart { get => legendPart;}

    public int NumPieParts 
    {
        get 
        { 
            return numPieParts;
        }
        set 
        {
            numPieParts = value;
            agendaString = new string[numPieParts];
            imagePieParts = new Image[numPieParts];
            //valPieParts = new float[numPieParts];
            valPieParts = new SortedDictionary<long, float>();
        }
    }
    public SortedDictionary<long, float> ValPieParts 
    {
        get => valPieParts;
        private set
        {
            foreach (var item in value)
            {
                valPieParts.Add(item.Key, item.Value);
            }

        }
    }
    public Image[] ImagePieParts 
    { 
        get => imagePieParts;
        private set
        {
            for(int i = 0; i < value.Length; i++)
            {
                imagePieParts[i] = value[i];
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
        foreach (var value in valPieParts)
        {
            sum += value.Value;
        }
         return sum;
    }

    public void DisplayNewValues(SortedDictionary<long, float> pieValues, Image[] imagePieParts, string[] agendaString)
    {
        SetValues
        (
            pieValues,
            GetComponentInChildren<PiePartContainer>().GeneratePieChartParts(pieValues),
            agendaString
        );

        GetComponentInChildren<Legend>().GenerateLegendParts(pieValues, ImagePieParts, AgendaString);

        CalcualteFillAmount();
    }

    public void SetValues(SortedDictionary<long, float> pieValues, Image[] imagePieParts, string[] agendaString)
    {
        ValPieParts = pieValues;
        ImagePieParts = imagePieParts;
        AgendaString = agendaString;
    }

    public void CalcualteFillAmount()
    {
        float totalValues = 0;
        float sum = FindSum();
        totalValues = 1; //max value

        int i = 0;
        foreach (var value in valPieParts)
        {
            ImagePieParts[i].fillAmount = totalValues;
            totalValues -= FindPercentage(sum, value.Key, valPieParts);
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
        return pieValues[index] / sum;
    }
}
