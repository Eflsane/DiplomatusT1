using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class AboutUserMinigameContainer : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown minigamesDropdown;
    [SerializeField]
    private List<TMPro.TextMeshProUGUI> paramsList = new List<TMPro.TextMeshProUGUI>();
    [SerializeField]
    private MonoColorBarChart scoreChart;
    [SerializeField]
    private MonoColorBarChart timechart;

    private UsersWithout currentUser;
    private List<Minigames> minigames;
    private List<UserMinigameStats> minigamesStatsByUserMinigame;

    private int selectedMinigameIndex = -1;

    public TMP_Dropdown MinigamesDropdown { get => minigamesDropdown; private set => minigamesDropdown = value; }
    public List<TextMeshProUGUI> ParamsList { get => paramsList; private set => paramsList = value; }
    public UsersWithout CurrentUser { get => currentUser; private set => currentUser = value; }
    public List<Minigames> Minigames { get => minigames; private set => minigames = value; }
    public List<UserMinigameStats> MinigamesStatsByUserMinigame { get => minigamesStatsByUserMinigame; private set => minigamesStatsByUserMinigame = value; }

    // Start is called before the first frame update
    void Start()
    {
        LoadMinigames();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetAllMinigames(List<Minigames> minigames)
    {
        this.Minigames = minigames;

        SetMinigamesDropdown();
    }

    private void SetMinigamesDropdown()
    {
        MinigamesDropdown.options.Clear();
        foreach (var minigame in Minigames)
        {
            MinigamesDropdown.options.Add(new TMP_Dropdown.OptionData($"{minigame.Id} - {minigame.Name}"));
        }
    }

    private void GetCurrentUser(UsersWithout user)
    {
        this.currentUser = user;
    }

    private void GetUserMinigameStatsByUserMinigame(List<UserMinigameStats> userMinigameStats)
    {
        this.MinigamesStatsByUserMinigame = userMinigameStats;

        SetUserMinigameData();

        scoreChart.GetComponentInChildren<CallMonoColorBarChartUserMinigameScore>().GetData(MinigamesStatsByUserMinigame);
        timechart.GetComponentInChildren<CallMonoColorBarChartUserMinigameTime>().GetData(MinigamesStatsByUserMinigame);
    }

    private void SetMinigameData()
    {
        ParamsList[0].text = Minigames[selectedMinigameIndex].Id.ToString();
        ParamsList[1].text = Minigames[selectedMinigameIndex].Name;
    }

    private void SetUserMinigameData()
    {
        ParamsList[2].text = minigamesStatsByUserMinigame.Count.ToString();

        float midTime = 0.0f;
        float midScore = 0.0f;
        foreach (var userMinigame in minigamesStatsByUserMinigame)
        {
            midTime += (float)(userMinigame.EndTime - userMinigame.BeginTime).TotalSeconds;
            midScore += (float)userMinigame.UserScore; 
        }
        midTime = midTime / (float)minigamesStatsByUserMinigame.Count;
        midScore = midScore / (float)minigamesStatsByUserMinigame.Count;
        ParamsList[3].text = $"{Mathf.FloorToInt(midTime / 60).ToString("0")}:{Mathf.FloorToInt(midTime % 60).ToString("0")}";
        ParamsList[6].text = midScore.ToString();

        ParamsList[4].text = minigamesStatsByUserMinigame.Max(x => x.UserScore).ToString();
        ParamsList[5].text = minigamesStatsByUserMinigame.Min(x => x.UserScore).ToString();
    }

    public void LoadMinigames()
    {
        CallUserController.Instance.OnDataMinigamesGetted += GetAllMinigames;
        CallUserController.Instance.OnDataUserMinigameStatsByUserMinigameGetted += GetUserMinigameStatsByUserMinigame;
        transform.parent.GetComponentInChildren<AboutUserController>().OnUserSelected += GetCurrentUser;
    }

    public void SelectMinigame(int index)
    {
        selectedMinigameIndex = index;

        SetMinigameData();

        CallUserController.Instance.GetUserMinigameStatsByUserMinigameData(currentUser.Username, minigames[index].Id);
    }
}
