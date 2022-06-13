using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class QuizesDTO : MonoBehaviour
{
    public static QuizesDTO Instance { get; private set; }

    public string dataURL = string.Empty;

    //public event Action<List<AdminsWithout>> OnGetAllAdminsSuccess = (List<AdminsWithout> dbAdminsWithout) => { };
    public event Action<List<Quizes>> OnGetAllQuizesSuccess = (List<Quizes> dbQuizes) => { };
    public event Action<Quizes> OnGetQuizSuccess = (Quizes dbQuizes) => { };
    public event Action OnUpdateQuizSuccess = () => { };
    public event Action<Quizes> OnAddQuizSuccess = (Quizes dbQuizes) => { };
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

    public void GetAllQuizes()
    {
        Debug.Log("startGettingQuizesData");
        StartCoroutine(GetAllQuizesCoroutine());
    }

    private IEnumerator GetAllQuizesCoroutine()
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

        List<Quizes> quizes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Quizes>>(request.downloadHandler.text);
        Debug.Log(quizes[0].Name);

        OnGetAllQuizesSuccess?.Invoke(quizes);
    }

    public void GetQuiz(long id)
    {
        Debug.Log("startGettingQuizesData");
        StartCoroutine(GetQuizCoroutine(id));
    }

    private IEnumerator GetQuizCoroutine(long id)
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

        Quizes quiz = Newtonsoft.Json.JsonConvert.DeserializeObject<Quizes>(request.downloadHandler.text);
        Debug.Log(quiz.Name);

        OnGetQuizSuccess?.Invoke(quiz);
    }

    public void UpdateQuiz(Quizes quiz)
    {
        Debug.Log("startEditingQuizesData");
        StartCoroutine(UpdateQuizCoroutine(quiz));
    }

    private IEnumerator UpdateQuizCoroutine(Quizes quiz)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(quiz);
        byte[] bytesIn = Encoding.UTF8.GetBytes(input);

        UnityWebRequest request = new UnityWebRequest($"{dataURL}/update/{quiz.ID}", "put");
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

        OnUpdateQuizSuccess?.Invoke();
    }

    public void AddQuiz(Quizes quiz)
    {
        Debug.Log("startAddQuizesData");
        StartCoroutine(AddQuizCoroutine(quiz));
    }

    private IEnumerator AddQuizCoroutine(Quizes quiz)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(quiz);
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

        Quizes newQuiz = Newtonsoft.Json.JsonConvert.DeserializeObject<Quizes>(request.downloadHandler.text);
        Debug.Log(newQuiz.ID);

        OnAddQuizSuccess?.Invoke(newQuiz);
    }
}

