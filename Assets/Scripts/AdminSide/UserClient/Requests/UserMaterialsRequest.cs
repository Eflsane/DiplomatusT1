using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UserMaterialsRequest : MonoBehaviour
{
    public static UserMaterialsRequest Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else if(Instance == this)
            Destroy(gameObject);
    }

    [SerializeField]
    private List<Image> avatars;
    [SerializeField]
    private List<GameObject> closedMats;
    [SerializeField]
    private List<GameObject> openedMats;
    private string username;

    [SerializeField]
    private Text usernameText;
    [SerializeField]
    private Text coinzText;

    private GoBack manager;

    List<UserOpennedMaterial> userOpennedMats;
    List<Materials> mats;


    public double coinz;

    DateTime beginDate;
    double score = 0;

    public List<GameObject> ClosedMats { get => closedMats; private set => closedMats = value; }
    public List<GameObject> OpenedMats { get => openedMats; private set => openedMats = value; }
    public string Username { get => username; private set => username = value; }

    // Start is called before the first frame update
    void Start()
    {
        StartGettingData();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartGettingData()
    {
        manager = GetComponentInParent<GoBack>();
        Username = PlayerPrefs.GetString(manager.prefUserName);

        UsersWithoutDTO.Instance.OnGetUserSuccess += FinishGettingData;
        UserOpennedMaterialDTO.Instance.OnGetUserOpennedMaterialsByUserSuccess += FinishGettingUserMatsData;
        UsersWithoutDTO.Instance.OnGUpdateCoinzSuccess += FinishUpdatingCoinz;
        //MinigamesDTO.Instance.OnGetAllMinigamesSuccess += FinishGettingMinigamesData;
        UserQuizStatsDTO.Instance.OnAddUserQuizStatsSuccess += FinishAddUserQuizStats;

        UsersWithoutDTO.Instance.GetUser(Username);

    }

    private void FinishGettingData(UsersWithout user)
    {
        avatars[(int)(user.AvatarID - 1)].gameObject.SetActive(true);
        usernameText.text = user.Username;
        coinzText.text = user.Coinz.ToString();
        coinz = user.Coinz;
        UsersWithoutDTO.Instance.OnGetUserSuccess -= FinishGettingData;
        UsersWithoutDTO.Instance.OnGetUserSuccess += UpdateIncreasedCoinz;
        UserOpennedMaterialDTO.Instance.GetUserOpennedMaterialssByUser(Username);
    }

    private void FinishGettingUserMatsData(List<UserOpennedMaterial> userOpenndedMats)
    {
        userOpennedMats = userOpenndedMats.GroupBy(x => x.MaterialId).Select(grp => grp.First()).ToList();

        OpenOwnedMats();
    }

    private void OpenOwnedMats()
    {
        foreach(var mat in userOpennedMats)
        {
            ClosedMats[(int)mat.MaterialId - 1].SetActive(false);
            OpenedMats[(int)mat.MaterialId - 1].SetActive(true);
        }
    }

    private void FinishUpdatingCoinz()
    {

    }

    public void IncreaseCoinz(int coinz)
    {
        UsersWithoutDTO.Instance.UpdateUserCoinz(new UsersWithout()
        {
            Username = username,
            Coinz = (double)coinz + this.coinz,
        });

        UsersWithoutDTO.Instance.GetUser(Username);
    }

    public void UpdateIncreasedCoinz(UsersWithout user)
    {
        coinzText.text = user.Coinz.ToString();
        coinz = user.Coinz;
    }

    public void AddUserQuizStats(int quizID)
    {
        UserQuizStatsDTO.Instance.AddUserQuizStats(new UserQuizStats()
        {
            Username = username,
            QuizID = quizID,
            BeginTime = beginDate,
            EndTime = DateTime.Now,
            UserScore = (int)score
        });
    }

    public void FinishAddUserQuizStats()
    {
        if(score >= 2) //this is just questions number in our 
        {
            IncreaseCoinz(50);
        }

        score = 0;
    }

    public void IncreaseScore()
    {
        score++;
    }

    public void StartQuiz()
    {
        beginDate = DateTime.Now;
    }
}
