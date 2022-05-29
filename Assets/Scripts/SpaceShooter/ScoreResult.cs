using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScoreResult : MonoBehaviour
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

    void UpdateScore()
    {
        string scoreStr = string.Format("{0:000000}", score);
        scoreTxt.text = scoreStr;
    }
}
