using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAddQuizController : MonoBehaviour
{
    public static CallAddQuizController Instance { get; private set; }

    public event Action<Quizes> OnDataQuizesAdd = (Quizes quiz) => { };
    public event Action OnDataQuizQuestsAdd = () => { };
    public event Action OnDataQuizQuestAnswersAdd = () => { };

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);
    }

    private void Start()
    {
        GetData();
    }

    public void GetData()
    {

    }

    public void AddQuizData(Quizes quiz)
    {
        QuizesDTO.Instance.OnAddQuizSuccess += AddQuizes;

        QuizesDTO.Instance.AddQuiz(quiz);
    }

    public void AddQuizes(Quizes quiz)
    {
        OnDataQuizesAdd?.Invoke(quiz);

        QuizesDTO.Instance.OnAddQuizSuccess -= AddQuizes;
    }

    public void AddQuizQuestsData(List<QuizQuestions> quizQuestions)
    {
        QuizQuestionsDTO.Instance.OnAddQuizQuestionsSuccess += AddQuizQuestions;

        QuizQuestionsDTO.Instance.AddManyQuizQuestions(quizQuestions);
    }

    public void AddQuizQuestions()
    {
        OnDataQuizQuestsAdd?.Invoke();

        QuizQuestionsDTO.Instance.OnAddQuizQuestionsSuccess -= AddQuizQuestions;
    }

    public void AddQuizQuestAnswersData(List<QuizQuestAnswers> quizQuestAnswers)
    {
        QuizQuestAnswersDTO.Instance.OnAddQuizQuestAnswersSuccess += AddQuizQuestAnswers;

        QuizQuestAnswersDTO.Instance.AddManyQuizQuestAnswers(quizQuestAnswers);
    }

    public void AddQuizQuestAnswers()
    {
        OnDataQuizQuestAnswersAdd?.Invoke();

        QuizQuestAnswersDTO.Instance.OnAddQuizQuestAnswersSuccess -= AddQuizQuestAnswers;
    }
}
