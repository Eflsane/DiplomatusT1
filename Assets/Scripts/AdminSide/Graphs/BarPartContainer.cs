using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarPartContainer : MonoBehaviour
{
    [SerializeField]
    private BarPart barPart;

    public int BarPartsCount { get => transform.childCount; }

    // Start is called before the first frame update
    void Awake()
    {
        barPart = GetComponentInParent<BarChart>().BarPart;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Image[] GenerateBarChartParts(SortedDictionary<long, float> charts)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        BarPart[] imageBarParts = new BarPart[charts.Count];

        for (int i = 0; i < imageBarParts.Length; i++)
        {
            imageBarParts[i] = Instantiate(barPart, this.transform, false);
            imageBarParts[i].Color = UnityEngine.Random.ColorHSV(0.0f, 1.0f, 0.38f, 0.8f, 0.38f, 0.8f);
        }

        var barChart = GetComponentInParent<BarChart>();
        barChart.NumBarParts = imageBarParts.Length; //automatic array genertation
        //pieChart.DisplayNewValues(charts, pieChart.ImagePieParts);

        Image[] images = new Image[imageBarParts.Length];
        for (int i = 0; i < images.Length; i++)
        {
            images[i] = imageBarParts[i].GetComponent<Image>();
        }

        return images;
    }
}
