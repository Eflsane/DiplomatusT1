using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class UserMinigameStatsDTO : MonoBehaviour
{
    public static UserMinigameStatsDTO Instance { get; private set; }

    public string dataURL = string.Empty;

    public event Action<List<UserMinigameStats>> OnGetAllUserMinigameStatsSuccess = (List<UserMinigameStats> dbUserMinigameStats) => { };
    public event Action<List<UserMinigameStats>> OnGetUserMinigameStatsByMinigameSuccess = (List<UserMinigameStats> dbUserMinigameStats) => { };
    public event Action<List<UserMinigameStats>> OnGetUserMinigameStatsByUserSuccess = (List<UserMinigameStats> dbUserMinigameStats) => { };
    public event Action<List<UserMinigameStats>> OnGetUserMinigameStatsByUserMinigameSuccess = (List<UserMinigameStats> dbUserMinigameStats) => { };
    public event Action OnAddUserMinigameStatsSuccess = () => { };
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetAllUserMinigameStats()
    {
        Debug.Log("startGettingMinigamesData");
        StartCoroutine(GetAllUserMinigameStatsCoroutine());
    }

    private IEnumerator GetAllUserMinigameStatsCoroutine()
    {
        UnityWebRequest request = new UnityWebRequest(dataURL, "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        List<UserMinigameStats> userMinigameStats = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserMinigameStats>>(request.downloadHandler.text);
        Debug.Log(userMinigameStats[0].MinigameId);

        OnGetAllUserMinigameStatsSuccess?.Invoke(userMinigameStats);
    }

    public void GetUserMinigameStatsByMinigame(long id)
    {
        Debug.Log("startGettingMinigamesData");
        StartCoroutine(GetUserMinigameStatsByMinigameCoroutine(id));
    }

    private IEnumerator GetUserMinigameStatsByMinigameCoroutine(long id)
    {
        UnityWebRequest request = new UnityWebRequest($"{dataURL}/Minigames/{id}", "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        List<UserMinigameStats> userMinigameStats = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserMinigameStats>>(request.downloadHandler.text);
        Debug.Log(userMinigameStats[0].MinigameId);

        OnGetUserMinigameStatsByMinigameSuccess?.Invoke(userMinigameStats);
    }

    public void GetUserMinigameStatsByUser(string username)
    {
        Debug.Log("startGettingMinigamesData");
        StartCoroutine(GetUserMinigameStatsByUserCoroutine(username));
    }

    private IEnumerator GetUserMinigameStatsByUserCoroutine(string username)
    {
        UnityWebRequest request = new UnityWebRequest($"{dataURL}/Users/{username}", "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        List<UserMinigameStats> userMinigameStats = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserMinigameStats>>(request.downloadHandler.text);
        Debug.Log(userMinigameStats[0].MinigameId);

        OnGetUserMinigameStatsByUserSuccess?.Invoke(userMinigameStats);
    }

    public void GetUserMinigameStatsByUserMinigame(string username, long id)
    {
        Debug.Log("startGettingMinigamesData");
        StartCoroutine(GetUserMinigameStatsByUserMinigameCoroutine(username, id));
    }

    private IEnumerator GetUserMinigameStatsByUserMinigameCoroutine(string username, long id)
    {
        UnityWebRequest request = new UnityWebRequest($"{dataURL}/Users/{username}/minigames/{id}", "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        List<UserMinigameStats> userMinigameStats = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserMinigameStats>>(request.downloadHandler.text);
        Debug.Log(userMinigameStats[0].MinigameId);

        OnGetUserMinigameStatsByUserMinigameSuccess?.Invoke(userMinigameStats);
    }

    public void AddUserMinigameStats(UserMinigameStats userMinigameStats)
    {
        Debug.Log("startAddMinigamesData");
        StartCoroutine(AddUserMinigameStatsCoroutine(userMinigameStats));
    }

    private IEnumerator AddUserMinigameStatsCoroutine(UserMinigameStats userMinigameStats)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(userMinigameStats);
        byte[] bytesIn = Encoding.UTF8.GetBytes(input);

        UnityWebRequest request = new UnityWebRequest($"{dataURL}/add", "post");
        request.SetRequestHeader("Content-Type", "application/json");
        request.uploadHandler = new UploadHandlerRaw(bytesIn);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        //Minigames minigame = Newtonsoft.Json.JsonConvert.DeserializeObject<Minigames>(request.downloadHandler.text);
        //Debug.Log(minigame.Name);

        OnAddUserMinigameStatsSuccess?.Invoke();
    }
}
