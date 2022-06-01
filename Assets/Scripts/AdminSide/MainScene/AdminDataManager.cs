using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminDataManager : MonoBehaviour
{
    public static AdminDataManager Instance { get; private set; }

    private string s = "CosmopediaAAngString";
    
    public string AName = string.Empty;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else if(Instance == this)
            Destroy(gameObject);
    }

    private void Start()
    {
        AName = PlayerPrefs.GetString(s);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey(s);
    }
}
