using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AboutQuiz : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown quizesDropdown;
    [SerializeField]
    private TMPro.TextMeshProUGUI idText;
    [SerializeField]
    private TMPro.TMP_InputField nameText;
    [SerializeField]
    private TMPro.TextMeshProUGUI creationDateText;
    [SerializeField]
    private TMPro.TMP_InputField scoreToUnlockText;
    [SerializeField]
    private TMPro.TMP_InputField descriptionText;
    [SerializeField]
    private List<TMPro.TextMeshProUGUI> paramsList = new List<TMPro.TextMeshProUGUI>();
    [SerializeField]
    private MonoColorBarChart scoreChart;
    [SerializeField]
    private MonoColorBarChart timechart;

    private UsersWithout currentUser;
    private List<Quizes> quizes;
    private List<UserQuizStats>quizStatsByQuiz;
    private List<UsersWithout> users;

    private int selectedQuizIndex = -1;

    public TMP_Dropdown QuizDropdown { get => quizesDropdown; private set => quizesDropdown = value; }
    public List<TextMeshProUGUI> ParamsList { get => paramsList; private set => paramsList = value; }
    public List<Quizes> Quizes { get => quizes; private set => quizes = value; }
    public List<UserQuizStats> QuizStatsByQuiz { get => quizStatsByQuiz; private set => quizStatsByQuiz = value; }

    // Start is called before the first frame update
    void Start()
    {
        LoadQuizes();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GetAllQuizes(List<Quizes> quizes)
    {
        this.Quizes = quizes;

        SetQuizesDropdown();
    }

    private void GetAllUsersCount(List<UsersWithout> users)
    {
        this.users = users;
    }

    private void SetQuizesDropdown()
    {
        QuizDropdown.options.Clear();
        QuizDropdown.Select();
        selectedQuizIndex = -1;
        quizesDropdown.value = -1;
        quizesDropdown.RefreshShownValue();
        foreach (var quiz in Quizes)
        {
            QuizDropdown.options.Add(new TMP_Dropdown.OptionData($"{quiz.ID} - {quiz.Name}"));
        }
    }

    private void GetUserQuizStatsByQuiz(List<UserQuizStats> userQuizStats)
    {
        this.quizStatsByQuiz = userQuizStats;

        SetUsersQuizData();

        scoreChart.GetComponentInChildren<CallMonoColorBarChartQuizScore>().GetData(QuizStatsByQuiz);
        timechart.GetComponentInChildren<CallMonoColorBarChartQuizTime>().GetData(QuizStatsByQuiz, Quizes[selectedQuizIndex].MaxScore);
    }

    private void SetQuizData()
    {
        idText.text = Quizes[selectedQuizIndex].ID.ToString();
        nameText.text = Quizes[selectedQuizIndex].Name;
        creationDateText.text = Quizes[selectedQuizIndex].CreationDate.ToShortDateString();
        scoreToUnlockText.text = Quizes[selectedQuizIndex].MaxScore.ToString();
        descriptionText.text = Quizes[selectedQuizIndex].Description;
    }

    private void SetUsersQuizData()
    {
        ParamsList[0].text = QuizStatsByQuiz.Count.ToString();

        float midTime = 0.0f;
        float midScore = 0.0f;
        int tries = 0;
        foreach (var userQuiz in QuizStatsByQuiz)
        {
            midTime += (float)(userQuiz.EndTime - userQuiz.BeginTime).TotalSeconds;
            midScore += (float)userQuiz.UserScore;
            if (userQuiz.UserScore >= quizes[selectedQuizIndex].MaxScore)
                tries++;
        }
        midTime = midTime / (float)QuizStatsByQuiz.Count;
        midScore = midScore / (float)QuizStatsByQuiz.Count;
        ParamsList[1].text = $"{Mathf.FloorToInt(midTime / 60).ToString("0")}:{Mathf.FloorToInt(midTime % 60).ToString("0")}";
        ParamsList[2].text = midScore.ToString("0.0");
        ParamsList[3].text = $"{tries.ToString()} ({tries / QuizStatsByQuiz.Count * 100}%)";

        //ParamsList[4].text = MinigamesStatsByMinigame.Max(x => x.UserScore).ToString();
        //ParamsList[5].text = MinigamesStatsByMinigame.Min(x => x.UserScore).ToString();
    }

    public void LoadQuizes()
    {
        CallQuizController.Instance.OnDataQuizesGetted += GetAllQuizes;
        CallQuizController.Instance.OnDataUserQuizStatsByQuizGetted += GetUserQuizStatsByQuiz;
        CallQuizController.Instance.OnDataUsersGetted += GetAllUsersCount;
    }

    public void SelectQuiz(int index)
    {
        selectedQuizIndex = index;

        SetQuizData();

        CallQuizController.Instance.GetUserQuizStatsByQuizData(quizes[index].ID);
    }

    public void UpdateQuiz()
    {
        Quizes quiz = new Quizes()
        {
            ID = quizes[selectedQuizIndex].ID,
            Name = nameText.text,
            CreationDate = quizes[selectedQuizIndex].CreationDate,
            Description = descriptionText.text,
            MaxScore = int.Parse(scoreToUnlockText.text)
        };
        CallQuizController.Instance.UpdateQuizesData(quiz);
    }
}
