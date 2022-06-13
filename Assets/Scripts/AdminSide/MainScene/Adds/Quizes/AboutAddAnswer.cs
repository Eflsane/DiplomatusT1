using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutAddAnswer : MonoBehaviour
{
    public int QuestCount { get => transform.childCount; }

    public List<AnswerAddPanel> answerAddPanels = new List<AnswerAddPanel>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearAnswers()
    {
        foreach (AnswerAddPanel answerAddPanel in answerAddPanels)
        {
            Destroy(answerAddPanel.gameObject);
        }

        answerAddPanels.Clear();
    }

    public void AddAnswer()
    {
        answerAddPanels.
            Add(Instantiate(GetComponentInParent<AboutAddQuizes>().aPanelPrefab, transform, false));
    }

    public void AddAnswer(AnswerAddPanel answerAddPanel)
    {
        answerAddPanels.Add(Instantiate(answerAddPanel, transform, false));
    }

    public List<QuizQuestAnswers> SaveChanges(QuizQuestions question)
    {
        List<QuizQuestAnswers> answers = new List<QuizQuestAnswers>();
        foreach (AnswerAddPanel answerAddPanel in answerAddPanels)
        {
            answers.Add(new QuizQuestAnswers()
            {
                QuizID = question.QuizID,
                QuestNum = question.QuestNum,
                Text = answerAddPanel.aText.text,
                IsRightAnswer = answerAddPanel.isRight.isOn
            });
        }

        return answers;
    }
}
