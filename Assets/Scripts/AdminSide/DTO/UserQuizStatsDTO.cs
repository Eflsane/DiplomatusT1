using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class UserQuizStatsDTO : MonoBehaviour
{
    public static UserQuizStatsDTO Instance { get; private set; }

    public string dataURL = string.Empty;

    public event Action<List<UserQuizStats>> OnGetAllUserQuizStatsSuccess = (List<UserQuizStats> dbUserQuizStats) => { };
    public event Action<List<UserQuizStats>> OnGetUserQuizStatsByQuizSuccess = (List<UserQuizStats> dbUserQuizStats) => { };
    public event Action<List<UserQuizStats>> OnGetUserQuizStatsByUserSuccess = (List<UserQuizStats> dbUserQuizStats) => { };
    public event Action<List<UserQuizStats>> OnGetUserQuizStatsByUserQuizSuccess = (List<UserQuizStats> dbUserQuizStats) => { };
    public event Action OnAddUserQuizStatsSuccess = () => { };
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

    public void GetAllUserQuizStats()
    {
        Debug.Log("startGettingQuizesData");
        StartCoroutine(GetAllUserQuizStatsCoroutine());
    }

    private IEnumerator GetAllUserQuizStatsCoroutine()
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

        List<UserQuizStats> userQuizStats = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserQuizStats>>(request.downloadHandler.text);
        Debug.Log(userQuizStats[0].QuizID);

        OnGetAllUserQuizStatsSuccess?.Invoke(userQuizStats);
    }

    public void GetUserQuizStatsByQuiz(long id)
    {
        Debug.Log("startGettingQuizesData");
        StartCoroutine(GetUserQuizStatsByQuizCoroutine(id));
    }

    private IEnumerator GetUserQuizStatsByQuizCoroutine(long id)
    {
        UnityWebRequest request = new UnityWebRequest($"{dataURL}/quizes/{id}", "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        List<UserQuizStats> userQuizStats = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserQuizStats>>(request.downloadHandler.text);
        Debug.Log(userQuizStats[0].QuizID);

        OnGetUserQuizStatsByQuizSuccess?.Invoke(userQuizStats);
    }

    public void GetUserQuizStatsByUser(string username)
    {
        Debug.Log("startGettingQuizesData");
        StartCoroutine(GetUserQuizStatsByUserCoroutine(username));
    }

    private IEnumerator GetUserQuizStatsByUserCoroutine(string username)
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

        List<UserQuizStats> userQuizStats = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserQuizStats>>(request.downloadHandler.text);
        Debug.Log(userQuizStats[0].QuizID);

        OnGetUserQuizStatsByUserSuccess?.Invoke(userQuizStats);
    }

    public void GetUserQuizStatsByUserQuiz(string username, long id)
    {
        Debug.Log("startGettingQuizesData");
        StartCoroutine(GetUserQuizStatsByUserQuizCoroutine(username, id));
    }

    private IEnumerator GetUserQuizStatsByUserQuizCoroutine(string username, long id)
    {
        UnityWebRequest request = new UnityWebRequest($"{dataURL}/Users/{username}/quizes/{id}", "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        List<UserQuizStats> userQuizStats = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserQuizStats>>(request.downloadHandler.text);
        Debug.Log(userQuizStats[0].QuizID);

        OnGetUserQuizStatsByUserQuizSuccess?.Invoke(userQuizStats);
    }

    public void AddUserQuizStats(UserQuizStats userQuizStats)
    {
        Debug.Log("startAddQuizesData");
        StartCoroutine(AddUserQuizStatsCoroutine(userQuizStats));
    }

    private IEnumerator AddUserQuizStatsCoroutine(UserQuizStats userQuizStats)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(userQuizStats);
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

        OnAddUserQuizStatsSuccess?.Invoke();
    }
}
