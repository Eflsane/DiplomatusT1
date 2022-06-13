using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class AboutUserQuiz : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown quizesDropdown;
    [SerializeField]
    private List<TMPro.TextMeshProUGUI> paramsList = new List<TMPro.TextMeshProUGUI>();
    [SerializeField]
    private MonoColorBarChart scoreChart;
    [SerializeField]
    private MonoColorBarChart timechart;

    private UsersWithout currentUser;
    private List<Quizes> quizes;
    private List<UserQuizStats> quizesStatsByUserQuiz;

    private int selectedQuizIndex = -1;

    public TMP_Dropdown QuizesDropdown { get => quizesDropdown; private set => quizesDropdown = value; }
    public List<TextMeshProUGUI> ParamsList { get => paramsList; private set => paramsList = value; }
    public UsersWithout CurrentUser { get => currentUser; private set => currentUser = value; }
    public List<Quizes> Quizes { get => quizes; private set => quizes = value; }
    public List<UserQuizStats> QuizesStatsByUserQuiz { get => quizesStatsByUserQuiz; private set => quizesStatsByUserQuiz = value; }

    // Start is called before the first frame update
    void Start()
    {
        LoadQuizes();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GetAllQuizes(List<Quizes> quiz)
    {
        this.Quizes = quiz;

        SetMinigamesDropdown();
    }

    private void SetMinigamesDropdown()
    {
        QuizesDropdown.options.Clear();
        foreach (var quiz in Quizes)
        {
            QuizesDropdown.options.Add(new TMP_Dropdown.OptionData($"{quiz.ID} - {quiz.Name}"));
        }
    }

    private void GetCurrentUser(UsersWithout user)
    {
        this.currentUser = user;
    }

    private void GetUserQuizStatsByUserQuiz(List<UserQuizStats> userQuizStats)
    {
        this.QuizesStatsByUserQuiz = userQuizStats;

        SetUserQuizData();

        scoreChart.GetComponentInChildren<CallMonoColorBarChartUserQuizScore>().GetData(QuizesStatsByUserQuiz);
        timechart.GetComponentInChildren<CallMonoColorBarChartUserQuizTime>().GetData(QuizesStatsByUserQuiz);
    }

    private void SetMinigameData()
    {
        //ParamsList[0].text = Quizes[selectedQuizIndex].ID.ToString();
        //ParamsList[1].text = Quizes[selectedQuizIndex].Name;
    }

    private void SetUserQuizData()
    {
        ParamsList[2].text = quizesStatsByUserQuiz.Count.ToString();

        float midTime = 0.0f;
        float midScore = 0.0f;
        foreach (var userMinigame in quizesStatsByUserQuiz)
        {
            midTime += (float)(userMinigame.EndTime - userMinigame.BeginTime).TotalSeconds;
            midScore += (float)userMinigame.UserScore;
        }
        midTime = midTime / (float)quizesStatsByUserQuiz.Count;
        midScore = midScore / (float)quizesStatsByUserQuiz.Count;
        ParamsList[3].text = $"{Mathf.FloorToInt(midTime / 60).ToString("0")}:{Mathf.FloorToInt(midTime % 60).ToString("0")}";
        ParamsList[6].text = midScore.ToString();

        ParamsList[4].text = quizesStatsByUserQuiz.Max(x => x.UserScore).ToString();
        ParamsList[5].text = quizesStatsByUserQuiz.Min(x => x.UserScore).ToString();
    }

    public void LoadQuizes()
    {
        CallUserController.Instance.OnDataQuizesGetted += GetAllQuizes;
        CallUserController.Instance.OnDataUserQuizStatsByUserQuizGetted += GetUserQuizStatsByUserQuiz;
        transform.parent.GetComponentInChildren<AboutUserController>().OnUserSelected += GetCurrentUser;
    }

    public void SelectQuiz(int index)
    {
        selectedQuizIndex = index;

        SetMinigameData();

        CallUserController.Instance.GetUserQuizStatsByUserQuizData(currentUser.Username, quizes[index].ID);
    }
}
