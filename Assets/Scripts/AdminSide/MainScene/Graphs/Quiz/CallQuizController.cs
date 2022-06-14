using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallQuizController : MonoBehaviour
{
    public static CallQuizController Instance { get; private set; }

    public event Action<List<Quizes>> OnDataQuizesGetted = (List<Quizes> quizes) => { };
    public event Action<List<UsersWithout>> OnDataUsersGetted = (List<UsersWithout> usersWithout) => { };
    public event Action<List<Genders>> OnDataGendersGetted = (List<Genders> genders) => { };
    public event Action<List<UserQuizStats>> OnDataUserQuizStatsByQuizGetted = (List<UserQuizStats> userQuizStats) => { };
    public event Action OnDataQuizesUpdated = () => { };

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
        QuizesDTO.Instance.OnGetAllQuizesSuccess += GetAllQuizes;

        QuizesDTO.Instance.GetAllQuizes();
    }

    public void GetAllQuizes(List<Quizes> quizes)
    {
        OnDataQuizesGetted?.Invoke(quizes);

        QuizesDTO.Instance.OnGetAllQuizesSuccess -= GetAllQuizes;

        //UsersWithoutDTO.Instance.GetAllUsers();
    }

    public void GetAllUsers(List<UsersWithout> usersWithout)
    {
        OnDataUsersGetted?.Invoke(usersWithout);

        UsersWithoutDTO.Instance.OnGetAllUsersSuccess -= GetAllUsers;

        GendersDTO.Instance.OnGetAllGendersSuccess += GetAllGenders;
        GendersDTO.Instance.GetAllGenders();
    }

    public void GetAllGenders(List<Genders> genders)
    {
        OnDataGendersGetted?.Invoke(genders);

        GendersDTO.Instance.OnGetAllGendersSuccess -= GetAllGenders;
    }

    public void GetUserQuizStatsByQuizData(long id)
    {
        UserQuizStatsDTO.Instance.OnGetUserQuizStatsByQuizSuccess += GetUserQuizStatsByQuiz;

        UserQuizStatsDTO.Instance.GetUserQuizStatsByQuiz(id);
    }

    public void GetUserQuizStatsByQuiz(List<UserQuizStats> userQuizStats)
    {
        OnDataUserQuizStatsByQuizGetted?.Invoke(userQuizStats);

        UserQuizStatsDTO.Instance.OnGetUserQuizStatsByQuizSuccess -= GetUserQuizStatsByQuiz;

        UsersWithoutDTO.Instance.OnGetAllUsersSuccess += GetAllUsers;
        UsersWithoutDTO.Instance.GetAllUsers();
    }

    public void UpdateQuizesData(Quizes quiz)
    {
        QuizesDTO.Instance.OnUpdateQuizSuccess += UpdateQuizes;

        QuizesDTO.Instance.UpdateQuiz(quiz);
    }

    public void UpdateQuizes()
    {
        OnDataQuizesUpdated?.Invoke();

        QuizesDTO.Instance.OnUpdateQuizSuccess -= UpdateQuizes;
    }
}
