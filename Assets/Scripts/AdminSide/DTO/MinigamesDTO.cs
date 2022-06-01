using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class MinigamesDTO : MonoBehaviour
{
    public static MinigamesDTO Instance { get; private set; }

    public string dataURL = string.Empty;

    public event Action<List<Minigames>> OnGetAllMinigamesSuccess = (List<Minigames> dbMinigames) => { };
    public event Action<Minigames> OnGetMinigameSuccess = (Minigames dbMinigames) => { };
    public event Action OnUpdateMinigameSuccess = () => { };
    public event Action OnAddMinigameSuccess = () => { };

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

    public void GetAllMinigames()
    {
        Debug.Log("startGettingMinigamesData");
        StartCoroutine(GetAllMinigamesCoroutine());
    }

    private IEnumerator GetAllMinigamesCoroutine()
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

        List<Minigames> minigames = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Minigames>>(request.downloadHandler.text);
        Debug.Log(minigames[0].Name);

        OnGetAllMinigamesSuccess?.Invoke(minigames);
    }

    public void GetMinigame(long id)
    {
        Debug.Log("startGettingMinigamesData");
        StartCoroutine(GetMinigameCoroutine(id));
    }

    private IEnumerator GetMinigameCoroutine(long id)
    {
        UnityWebRequest request = new UnityWebRequest($"{dataURL}/{id}", "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        Minigames minigame = Newtonsoft.Json.JsonConvert.DeserializeObject<Minigames>(request.downloadHandler.text);
        Debug.Log(minigame.Name);

        OnGetMinigameSuccess?.Invoke(minigame);
    }

    public void UpdateMinigame(Minigames minigame)
    {
        Debug.Log("startEditingMinigamesData");
        StartCoroutine(UpdateMinigameCoroutine(minigame));
    }

    private IEnumerator UpdateMinigameCoroutine(Minigames minigame)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(minigame);
        byte[] bytesIn = Encoding.UTF8.GetBytes(input);

        UnityWebRequest request = new UnityWebRequest($"{dataURL}/update/{minigame.Id}", "put");
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

        OnUpdateMinigameSuccess?.Invoke();
    }

    public void AddMinigame(Minigames minigame)
    {
        Debug.Log("startAddMinigamesData");
        StartCoroutine(AddMinigameCoroutine(minigame));
    }

    private IEnumerator AddMinigameCoroutine(Minigames minigame)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(minigame);
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

        OnAddMinigameSuccess?.Invoke();
    }
}
