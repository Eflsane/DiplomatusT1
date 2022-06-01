using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScore : MonoBehaviour
{
    Text scoreTxt;

    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScore();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreTxt = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateScore()
    {
        string scoreStr = string.Format("{0:0}", score);
        scoreTxt.text = scoreStr;
    }
}
