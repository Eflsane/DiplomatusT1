using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiePartContainer : MonoBehaviour
{
    [SerializeField]
    private PiePart piePart;

    public int PiePartsCount { get => transform.childCount; }

    // Start is called before the first frame update
    void Start()
    {
        piePart = GetComponentInParent<PieChart>().PiePart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Image[] GeneratePieChartParts(SortedDictionary<long, float> charts)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        PiePart[] imagePieParts = new PiePart[charts.Count];

        for (int i = 0; i < imagePieParts.Length; i++)
        {
            imagePieParts[i] = Instantiate(piePart, this.transform, false);
            imagePieParts[i].Color = UnityEngine.Random.ColorHSV(0.0f, 1.0f, 0.38f, 0.8f, 0.38f, 0.8f);
        }

        var pieChart = GetComponentInParent<PieChart>();
        pieChart.NumPieParts = imagePieParts.Length; //automatic array genertation
        //pieChart.DisplayNewValues(charts, pieChart.ImagePieParts);

        Image[] images = new Image[imagePieParts.Length];
        for(int i = 0; i < images.Length; i++)
        {
            images[i] = imagePieParts[i].GetComponent<Image>();
        }

        return images;
    }
}
