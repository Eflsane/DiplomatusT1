using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public GameObject score;
   // public GameObject Result;
    public GameObject positive;
    public GameObject bad;
    public GameObject Vic;
    int x;
    int y;
    GameObject scoreTxt;

    public enum GameManagerState
    {
        GetAc,
        Hold,
        Question1,
        Question2,
        Question3,
        Question4,
        Question5,
        Result,

    }

    GameManagerState GMState;

    // Start is called before the first frame update
    void Start()
    {
        scoreTxt = GameObject.FindGameObjectWithTag("Score");
    }

    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.GetAc:

                if (y == 2)
                {
                    Vic.SetActive(true);
                }
                else ChangeToHold();


                break;
            case GameManagerState.Hold:
                Debug.Log(y);
                break;
            case GameManagerState.Question1:

                break;

            case GameManagerState.Question2:

                break;
            case GameManagerState.Question3:

                break;
            case GameManagerState.Question4:

                break;
            case GameManagerState.Question5:

                break;
            case GameManagerState.Result:

                
                if (x == 2) 
                {
                    positive.SetActive(true);
                }
                if (x < 2)
                {
                    bad.SetActive(true);
                }

                ChangeToHold();

                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }
    public void ChangeToRes()
    {
        SetGameManagerState(GameManagerState.Result);
    }
    public void ChangeToVic()
    {
        SetGameManagerState(GameManagerState.GetAc);
    }
    public void ChangeToHold()
    {
        SetGameManagerState(GameManagerState.Hold);
    }


    public void Res()
    {
        x = score.GetComponent<GameScore>().Score;
        //Result.GetComponent<GameScore>().Score = x;
    }
    public void AddScore()
    {
        x += 1;
    }
    public void Addlamp()
    {
        y += 1;
    }
}
