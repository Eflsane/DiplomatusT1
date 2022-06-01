using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAddMinigameController : MonoBehaviour
{
    public static CallAddMinigameController Instance { get; private set; }

    public event Action OnDataMinigamesAdd = () => { };

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);
    }

    private void Start()
    {
        GetData();
    }

    public void GetData()
    {
        
    }

    public void AddMinigamesData(Minigames minigame)
    {
        MinigamesDTO.Instance.OnAddMinigameSuccess += AddMinigames;

        MinigamesDTO.Instance.AddMinigame(minigame);
    }

    public void AddMinigames()
    {
        OnDataMinigamesAdd?.Invoke();

        MinigamesDTO.Instance.OnAddMinigameSuccess -= AddMinigames;
    }
}
