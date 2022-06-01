using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MonoColorBarChart : MonoBehaviour
{
    [SerializeField]
    private BarPart barPart;
    [SerializeField]
    private int numBarParts;
    [SerializeField]
    private Image[] imageMonoColorBarParts;
    [SerializeField]
    private SortedDictionary<long, float> valMonoColorBarParts;
    private string[] agendaString;

    public BarPart BarPart { get => barPart; }

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
            imageMonoColorBarParts = new Image[numBarParts];
            //valBarParts = new float[numPieParts];
            valMonoColorBarParts = new SortedDictionary<long, float>();
        }
    }
    public SortedDictionary<long, float> ValMonoColorBarParts
    {
        get => valMonoColorBarParts;
        private set
        {
            foreach (var item in value)
            {
                valMonoColorBarParts.Add(item.Key, item.Value);
            }

        }
    }
    public Image[] ImageMonoColorBarParts
    {
        get => imageMonoColorBarParts;
        private set
        {
            for (int i = 0; i < value.Length; i++)
            {
                imageMonoColorBarParts[i] = value[i];
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
        foreach (var value in valMonoColorBarParts)
        {
            sum += value.Value;
        }
        return sum;
    }

    public void DisplayNewValues(SortedDictionary<long, float> monoColorBarValues, Image[] imageMonoColorBarParts, string[] agendaString)
    {
        SetValues
        (
            monoColorBarValues,
            GetComponentInChildren<MonoColorBarPartContainer>().GenerateMonoColorBarChartParts(monoColorBarValues),
            agendaString
        );

        SetMaxMinText();

        CalcualteFillAmount();
    }

    public void SetValues(SortedDictionary<long, float> monoColorarValues, Image[] imageMonoColorBarParts, string[] agendaString)
    {
        ValMonoColorBarParts = monoColorarValues;
        ImageMonoColorBarParts = imageMonoColorBarParts;
        AgendaString = agendaString;
    }

    public void SetMaxMinText()
    {
        var texts = GetComponentsInChildren<TMPro.TextMeshProUGUI>();
        Debug.Log(texts[0]);
        texts[0].text = ValMonoColorBarParts.Max(x => x.Value).ToString();
        Debug.Log(texts[1]);
        texts[1].text = 0.ToString();
    }

    public void CalcualteFillAmount()
    {
        float totalValues = 0;
        float sum = FindSum();
        totalValues = 1; //max value

        int i = 0;
        foreach (var value in valMonoColorBarParts)
        {
            ImageMonoColorBarParts[i].fillAmount = FindPercentage(i, ValMonoColorBarParts);
            i++;
            Debug.Log("s - " + value.Value);
        }
    }




    public float FindPercentage(long index, SortedDictionary<long, float> pieValues)
    {
        float max = pieValues.Max(x => x.Value);
        return pieValues[index] / max;
    }
}
