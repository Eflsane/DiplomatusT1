using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonoColorBarPartContainer : MonoBehaviour
{
    [SerializeField]
    private BarPart barPart;

    public int BarPartsCount { get => transform.childCount; }

    // Start is called before the first frame update
    void Awake()
    {
        barPart = GetComponentInParent<MonoColorBarChart>().BarPart;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Image[] GenerateMonoColorBarChartParts(SortedDictionary<long, float> charts)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        BarPart[] imageMonoColorBarParts = new BarPart[charts.Count];
        Color barColor = UnityEngine.Random.ColorHSV(0.0f, 1.0f, 0.38f, 0.8f, 0.38f, 0.8f);

        for (int i = 0; i < imageMonoColorBarParts.Length; i++)
        {
            imageMonoColorBarParts[i] = Instantiate(barPart, this.transform, false);
            imageMonoColorBarParts[i].Color = barColor;
        }

        var monoColorbarChart = GetComponentInParent<MonoColorBarChart>();
        monoColorbarChart.NumBarParts = imageMonoColorBarParts.Length; //automatic array genertation
        //pieChart.DisplayNewValues(charts, pieChart.ImagePieParts);

        Image[] images = new Image[imageMonoColorBarParts.Length];
        for (int i = 0; i < images.Length; i++)
        {
            images[i] = imageMonoColorBarParts[i].GetComponent<Image>();
        }

        return images;
    }
}
