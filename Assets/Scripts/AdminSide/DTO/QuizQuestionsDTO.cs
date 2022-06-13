using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class QuizQuestionsDTO : MonoBehaviour
{
    public static QuizQuestionsDTO Instance { get; private set; }

    public string dataURL = string.Empty;

    public event Action<List<QuizQuestions>> OnGetAllQuizQuestionsSuccess = (List<QuizQuestions> dbQuizQuestions) => { };
    public event Action<List<QuizQuestions>> OnGetQuizQuestionsByQuizSuccess = (List<QuizQuestions> dbQuizQuestions) => { };
    public event Action<List<QuizQuestions>> OnGetQuizQuestionsByQuizQuestSuccess = (List<QuizQuestions> dbQuizQuestions) => { };
    public event Action OnUpdateQuizQuestionsSuccess = () => { };
    public event Action OnAddQuizQuestionsSuccess = () => { };
    public event Action OnDeleteQuizQuestionsSuccess = () => { };

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

    public void GetAllQuizQuestions()
    {
        Debug.Log("startGettingQuizesData");
        StartCoroutine(GetAllQuizQuestionsCoroutine());
    }

    private IEnumerator GetAllQuizQuestionsCoroutine()
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

        List<QuizQuestions> quizQuestions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<QuizQuestions>>(request.downloadHandler.text);
        Debug.Log(quizQuestions[0].QuizID);

        OnGetAllQuizQuestionsSuccess?.Invoke(quizQuestions);
    }

    public void GetQuizQuestionsByQuiz(long id)
    {
        Debug.Log("startGettingQuizesData");
        StartCoroutine(GetQuizQuestionsByQuizCoroutine(id));
    }

    private IEnumerator GetQuizQuestionsByQuizCoroutine(long id)
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

        List<QuizQuestions> quizQuestions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<QuizQuestions>>(request.downloadHandler.text);
        Debug.Log(quizQuestions[0].QuizID);

        OnGetQuizQuestionsByQuizSuccess?.Invoke(quizQuestions);
    }

    public void GetQuizQuestionsByQuizQuest(long id, int num)
    {
        Debug.Log("startGettingQuizesData");
        StartCoroutine(GetQuizQuestionsByQuizQuestCoroutine(id, num));
    }

    private IEnumerator GetQuizQuestionsByQuizQuestCoroutine(long id, int num)
    {
        UnityWebRequest request = new UnityWebRequest($"{dataURL}/quizes/{id}/questions{num}", "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        List<QuizQuestions> quizQuestions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<QuizQuestions>>(request.downloadHandler.text);
        Debug.Log(quizQuestions[0].QuizID);

        OnGetQuizQuestionsByQuizQuestSuccess?.Invoke(quizQuestions);
    }

    public void UpdateQuizQuestion(QuizQuestions quizQuestions)
    {
        Debug.Log("startEditingQuizesData");
        StartCoroutine(UpdateQuizQuestionCoroutine(quizQuestions));
    }

    private IEnumerator UpdateQuizQuestionCoroutine(QuizQuestions quizQuestions)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(quizQuestions);
        byte[] bytesIn = Encoding.UTF8.GetBytes(input);

        UnityWebRequest request = new UnityWebRequest($"{dataURL}/update/quizes/{quizQuestions.QuizID}/questions/{quizQuestions.QuestNum}", "put");
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

        OnUpdateQuizQuestionsSuccess?.Invoke();
    }

    public void AddQuizQuestion(QuizQuestions quizQuestion)
    {
        Debug.Log("startAddQuizesData");
        StartCoroutine(AddQuizQuestionCoroutine(quizQuestion));
    }

    private IEnumerator AddQuizQuestionCoroutine(QuizQuestions quizQuestion)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(quizQuestion);
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

        OnAddQuizQuestionsSuccess?.Invoke();
    }

    public void AddManyQuizQuestions(List<QuizQuestions> quizQuestions)
    {
        Debug.Log("startAddQuizesData");
        StartCoroutine(AddManyQuizQuestionsCoroutine(quizQuestions));
    }

    private IEnumerator AddManyQuizQuestionsCoroutine(List<QuizQuestions> quizQuestions)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(quizQuestions);
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

        OnAddQuizQuestionsSuccess?.Invoke();
    }

    public void DeleteQuizQuestion(long id, int num)
    {
        Debug.Log("startDeleteQuizesData");
        StartCoroutine(DeleteQuizQuestionCoroutine(id, num));
    }

    private IEnumerator DeleteQuizQuestionCoroutine(long id, int num)
    {
        UnityWebRequest request = new UnityWebRequest($"{dataURL}/delete/quizes/{id}/questions/{num}", "delete");
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

        OnDeleteQuizQuestionsSuccess?.Invoke();
    }

    public void DeleteManyQuizQuestions(List<QuizQuestions> quizQuestions)
    {
        Debug.Log("startDeleteQuizesData");
        StartCoroutine(DeleteManyQuizQuestionsCoroutine(quizQuestions));
    }

    private IEnumerator DeleteManyQuizQuestionsCoroutine(List<QuizQuestions> quizQuestions)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(quizQuestions);
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

        OnDeleteQuizQuestionsSuccess?.Invoke();
    }
}

