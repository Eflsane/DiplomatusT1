using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemySpawner;
    public GameObject Tutorial;
    public GameObject GameOver;
    public GameObject Score;
    public GameObject Score1;
    public GameObject ScoreRes;
    public GameObject Scorecont;
    public GameObject ScoreBoard;
    int x;
    DateTime beginDate;

    public event Action<double, double, DateTime> OnGameOverApeared = (double coinz, double score, DateTime beginDate) => { };

    public enum GameManagerState 
    { 
        Tutoria,
        Opening,
        
        GameOver,
        AfterOver,
    }

    GameManagerState GMState;

    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManagerState.Tutoria;
        beginDate = DateTime.Now;
    }

    void UpdateGameManagerState() 
    {
        switch (GMState)
        {
            case GameManagerState.Tutoria:

                Tutorial.SetActive(true);
                Scorecont.SetActive(false);
                break;

            case GameManagerState.Opening:

                StartThisShit();
                break;
            
            case GameManagerState.GameOver:

                enemySpawner.GetComponent<EnemySpawner>().StopSpawn();

                GameOver.SetActive(true);

                Invoke("ChangeToAOState", 3f);

                

                break;
            case GameManagerState.AfterOver:

                

                ScoreBoard.SetActive(true);
                Invoke("Res", 0.2f);
                Invoke("Deactivate", 0.1f);



                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void ChangeToAOState()
    {
        SetGameManagerState(GameManagerState.AfterOver);
    }
    public void Deactivate()
    {
        Scorecont.SetActive(false);
    }

    public void Res()
    {
        x = Score1.GetComponent<GameScore>().Score;
        ScoreRes.GetComponent<GameScore>().Score = x;

        OnGameOverApeared?.Invoke(150.0, (double)x, beginDate);
    }

    public void ChangeToOState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
    public void StartThisShit()
    {
        Scorecont.SetActive(true);
        Tutorial.SetActive(false);
        player.GetComponent<PlayerMove>().Init();
        enemySpawner.GetComponent<EnemySpawner>().StartSpawn();
        GameOver.SetActive(false);
        Score.GetComponent<GameScore>().Score = 0;
        Score1.GetComponent<GameScore>().Score = 0;
        
    }

}
