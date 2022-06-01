using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LegendPart : MonoBehaviour
{
    Color color;
    [SerializeField]
    public Color Color
    {
        get => color;
        set
        {
            color = value;
            transform.GetChild(0).
                transform.GetChild(0).GetComponent<Image>().
                color = color;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
