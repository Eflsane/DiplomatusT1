using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutAddQuests : MonoBehaviour
{
    public int QuestCount { get => transform.childCount - 1; }

    public List<QuestionAddPanel> questionAddPanels = new List<QuestionAddPanel>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearQuests()
    {
        foreach (QuestionAddPanel questionAddPanel in questionAddPanels)
        {
            /*questionAddPanel.GetComponentInChildren<AboutAddAnswer>().
                ClearAnswers();*/
            Destroy(questionAddPanel.gameObject);
        }

        questionAddPanels.Clear();
    }


    public void RefreshQuestsNums()
    {
        for(int i = 0; i < questionAddPanels.Count; i++)
        {
            questionAddPanels[i].qNum.text = (i + 1).ToString();
        }
    }


    public void AddQuest(QuestionAddPanel questionAddPanel)
    {
        questionAddPanels.Add(Instantiate(questionAddPanel, transform, false));

        RefreshQuestsNums();
    }

    public void AddAnswer(AnswerAddPanel answerPanel)
    {
        GetComponentInChildren<AboutAddAnswer>().
            AddAnswer(answerPanel);
    }

    public List<QuizQuestions> SaveChanges(Quizes quiz)
    {
        List<QuizQuestions> questions = new List<QuizQuestions>();
        foreach (QuestionAddPanel questionAddPanel in questionAddPanels)
        {
            questions.Add( new QuizQuestions()
            {
                QuizID = quiz.ID,
                QuestNum = questionAddPanels.IndexOf(questionAddPanel) + 1,
                Text = questionAddPanel.qText.text
            });
        }

        return questions;
    }

    public List<QuizQuestAnswers> SaveAnswersChanges(List<QuizQuestions> questions)
    {
        List<QuizQuestAnswers> answers = new List<QuizQuestAnswers>();

        for (int i = 0; i < questions.Count; i++)
        {
            answers.AddRange
            (
                questionAddPanels[i].
                GetComponentInChildren<AboutAddAnswer>().
                SaveChanges(questions[i])
            );
        }
        return answers;
    }
}
