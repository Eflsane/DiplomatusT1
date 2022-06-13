using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutAddQuizes : MonoBehaviour
{
    [SerializeField]
    TMPro.TMP_InputField nameText;
    [SerializeField]
    TMPro.TMP_InputField descText;
    [SerializeField]
    TMPro.TMP_InputField maxScoreText;

    [SerializeField]
    public QuestionAddPanel qPanelPrefab;

    [SerializeField]
    public AnswerAddPanel aPanelPrefab;

    //public List<QuestionAddPanel> questionAddPanels = new List<QuestionAddPanel>();
    public List<QuizQuestions> questions = new List<QuizQuestions>();
    public List<QuizQuestAnswers> answers = new List<QuizQuestAnswers>();
    // Start is called before the first frame update
    void Start()
    {
        SetData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData()
    {
        CallAddQuizController.Instance.OnDataQuizesAdd += AfterSaved;
        CallAddQuizController.Instance.OnDataQuizQuestsAdd += AfterQuestsSaved;
        CallAddQuizController.Instance.OnDataQuizQuestAnswersAdd += AfterQuizQuestAnswersSaved;


        Clear();

        //other clears     
    } 

    public void Clear()
    {
        GetComponentInChildren<AboutAddQuests>().ClearQuests();
        questions.Clear();
        answers.Clear();

        nameText.text = string.Empty;
        descText.text = string.Empty;
        maxScoreText.text = string.Empty;
    }

    public void AddQuest()
    {
        GetComponentInChildren<AboutAddQuests>().
            AddQuest(qPanelPrefab);
    }

    public void AddAnswer()
    {
        GetComponentInChildren<AboutAddQuests>().
            AddAnswer(aPanelPrefab);
    }

    public void SaveChanges()
    {
        Quizes newQuiz = new Quizes()
        {
            Name = nameText.text,
            Description = descText.text,
            MaxScore = int.Parse(maxScoreText.text),
            CreationDate = System.DateTime.Now,
        };

        CallAddQuizController.Instance.AddQuizData(newQuiz);
        //Connect to controller add yourself and then start adding questions;
    }
    
    public void AfterSaved(Quizes quiz)
    {
        questions = GetComponentInChildren<AboutAddQuests>().SaveChanges(quiz);

        CallAddQuizController.Instance.AddQuizQuestsData(questions);
    }

    public void AfterQuestsSaved()
    {
        answers = GetComponentInChildren<AboutAddQuests>().SaveAnswersChanges(questions);

        CallAddQuizController.Instance.AddQuizQuestAnswersData(answers);
    }

    public void AfterQuizQuestAnswersSaved()
    {
        Clear();

        
    }
}
