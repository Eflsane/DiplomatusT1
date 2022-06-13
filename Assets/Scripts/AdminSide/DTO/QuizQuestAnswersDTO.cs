using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class QuizQuestAnswersDTO : MonoBehaviour
{
    public static QuizQuestAnswersDTO Instance { get; private set; }

    public string dataURL = string.Empty;

    public event Action<List<QuizQuestAnswers>> OnGetAllQuizQuestAnswersSuccess = (List<QuizQuestAnswers> dbQuizQuestAnswers) => { };
    public event Action<List<QuizQuestAnswers>> OnGetQuizQuestAnswersByQuizSuccess = (List<QuizQuestAnswers> dbQuizQuestAnswers) => { };
    public event Action<List<QuizQuestAnswers>> OnGetQuizQuestAnswersByQuizQuestSuccess = (List<QuizQuestAnswers> dbQuizQuestAnswers) => { };
    public event Action OnUpdateQuizQuestAnswersSuccess = () => { };
    public event Action OnAddQuizQuestAnswersSuccess = () => { };
    public event Action OnDeleteQuizQuestAnswersSuccess = () => { };

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

    public void GetAllQuizQuestAnswers()
    {
        Debug.Log("startGettingQuizesData");
        StartCoroutine(GetAllQuizQuestAnswersCoroutine());
    }

    private IEnumerator GetAllQuizQuestAnswersCoroutine()
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

        List<QuizQuestAnswers> quizQuestAnswers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<QuizQuestAnswers>>(request.downloadHandler.text);
        Debug.Log(quizQuestAnswers[0].QuizID);

        OnGetAllQuizQuestAnswersSuccess?.Invoke(quizQuestAnswers);
    }

    public void GetQuizQuestAnswersByQuiz(long id)
    {
        Debug.Log("startGettingQuizesData");
        StartCoroutine(GetQuizQuestAnswersByQuizCoroutine(id));
    }

    private IEnumerator GetQuizQuestAnswersByQuizCoroutine(long id)
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

        List<QuizQuestAnswers> quizQuestAnswers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<QuizQuestAnswers>>(request.downloadHandler.text);
        Debug.Log(quizQuestAnswers[0].QuizID);

        OnGetQuizQuestAnswersByQuizSuccess?.Invoke(quizQuestAnswers);
    }

    public void GetQuizQuestAnswersByQuizQuest(long id, int num)
    {
        Debug.Log("startGettingQuizesData");
        StartCoroutine(GetQuizQuestAnswersByQuizQuestCoroutine(id, num));
    }

    private IEnumerator GetQuizQuestAnswersByQuizQuestCoroutine(long id, int num)
    {
        UnityWebRequest request = new UnityWebRequest($"{dataURL}/quizes/{id}/quest{num}", "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        List<QuizQuestAnswers> quizQuestAnswers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<QuizQuestAnswers>>(request.downloadHandler.text);
        Debug.Log(quizQuestAnswers[0].QuizID);

        OnGetQuizQuestAnswersByQuizQuestSuccess?.Invoke(quizQuestAnswers);
    }

    public void UpdateQuizQuestAnswers(QuizQuestAnswers quizQuestAnswers)
    {
        Debug.Log("startEditingQuizesData");
        StartCoroutine(UpdateQuizQuestAnswersCoroutine(quizQuestAnswers));
    }

    private IEnumerator UpdateQuizQuestAnswersCoroutine(QuizQuestAnswers quizQuestAnswer)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(quizQuestAnswer);
        byte[] bytesIn = Encoding.UTF8.GetBytes(input);

        UnityWebRequest request = new UnityWebRequest($"{dataURL}/update/{quizQuestAnswer.ID}", "put");
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

        OnUpdateQuizQuestAnswersSuccess?.Invoke();
    }

    public void AddQuizQuestAnswers(QuizQuestAnswers quizQuestAnswers)
    {
        Debug.Log("startAddQuizesData");
        StartCoroutine(AddQuizQuestAnswersCoroutine(quizQuestAnswers));
    }

    private IEnumerator AddQuizQuestAnswersCoroutine(QuizQuestAnswers quizQuestAnswers)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(quizQuestAnswers);
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

        OnAddQuizQuestAnswersSuccess?.Invoke();
    }

    public void AddManyQuizQuestAnswers(List<QuizQuestAnswers> quizQuestAnswers)
    {
        Debug.Log("startAddQuizesData");
        StartCoroutine(AddManyQuizQuestAnswersCoroutine(quizQuestAnswers));
    }

    private IEnumerator AddManyQuizQuestAnswersCoroutine(List<QuizQuestAnswers> quizQuestAnswers)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(quizQuestAnswers);
        byte[] bytesIn = Encoding.UTF8.GetBytes(input);

        UnityWebRequest request = new UnityWebRequest($"{dataURL}/addMany", "post");
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

        OnAddQuizQuestAnswersSuccess?.Invoke();
    }

    public void DeleteQuizQuestAnswers(long id)
    {
        Debug.Log("startDeleteQuizesData");
        StartCoroutine(DeleteQuizQuestAnswersCoroutine(id));
    }

    private IEnumerator DeleteQuizQuestAnswersCoroutine(long id)
    {
        UnityWebRequest request = new UnityWebRequest($"{dataURL}/delete/{id}", "delete");
        request.SetRequestHeader("Content-Type", "application/json");
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

        OnDeleteQuizQuestAnswersSuccess?.Invoke();
    }

    public void DeleteManyQuizQuestAnswers(List<QuizQuestAnswers> quizQuestAnswers)
    {
        Debug.Log("startDeleteQuizesData");
        StartCoroutine(DeleteManyQuizQuestAnswersCoroutine(quizQuestAnswers));
    }

    private IEnumerator DeleteManyQuizQuestAnswersCoroutine(List<QuizQuestAnswers> quizQuestAnswers)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(quizQuestAnswers);
        byte[] bytesIn = Encoding.UTF8.GetBytes(input);

        UnityWebRequest request = new UnityWebRequest($"{dataURL}/deleteMany", "delete");
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

        OnDeleteQuizQuestAnswersSuccess?.Invoke();
    }
}

