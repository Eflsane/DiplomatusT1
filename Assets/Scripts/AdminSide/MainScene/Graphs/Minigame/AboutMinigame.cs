using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class AboutMinigame : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown minigamesDropdown;
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
    private List<Minigames> minigames;
    private List<UserMinigameStats> minigamesStatsByMinigame;

    private int selectedMinigameIndex = -1;

    public TMP_Dropdown MinigamesDropdown { get => minigamesDropdown; private set => minigamesDropdown = value; }
    public List<TextMeshProUGUI> ParamsList { get => paramsList; private set => paramsList = value; }
    public UsersWithout CurrentUser { get => currentUser; private set => currentUser = value; }
    public List<Minigames> Minigames { get => minigames; private set => minigames = value; }
    public List<UserMinigameStats> MinigamesStatsByMinigame { get => minigamesStatsByMinigame; private set => minigamesStatsByMinigame = value; }

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

    private void GetUserMinigameStatsByMinigame(List<UserMinigameStats> userMinigameStats)
    {
        this.MinigamesStatsByMinigame = userMinigameStats;

        SetUsersMinigameData();

        scoreChart.GetComponentInChildren<CallMonoColorBarChartMinigameScore>().GetData(MinigamesStatsByMinigame);
        timechart.GetComponentInChildren<CallMonoColorBarChartMinigameTime>().GetData(MinigamesStatsByMinigame);
    }

    private void SetMinigameData()
    {
        idText.text = Minigames[selectedMinigameIndex].Id.ToString();
        nameText.text = Minigames[selectedMinigameIndex].Name;
        creationDateText.text = Minigames[selectedMinigameIndex].CreationDate.ToShortDateString();
        scoreToUnlockText.text = Minigames[selectedMinigameIndex].ScoreToUnlock.ToString();
        descriptionText.text = Minigames[selectedMinigameIndex].Description;
    }

    private void SetUsersMinigameData()
    {
        ParamsList[0].text = MinigamesStatsByMinigame.Count.ToString();

        float midTime = 0.0f;
        float midScore = 0.0f;
        foreach (var userMinigame in MinigamesStatsByMinigame)
        {
            midTime += (float)(userMinigame.EndTime - userMinigame.BeginTime).TotalSeconds;
            midScore += (float)userMinigame.UserScore;
        }
        midTime = midTime / (float)MinigamesStatsByMinigame.Count;
        midScore = midScore / (float)MinigamesStatsByMinigame.Count;
        ParamsList[1].text = $"{Mathf.FloorToInt(midTime / 60).ToString("0")}:{Mathf.FloorToInt(midTime % 60).ToString("0")}";
        ParamsList[2].text = midScore.ToString("0.0");

        //ParamsList[4].text = MinigamesStatsByMinigame.Max(x => x.UserScore).ToString();
        //ParamsList[5].text = MinigamesStatsByMinigame.Min(x => x.UserScore).ToString();
    }

    public void LoadMinigames()
    {
        CallMinigameController.Instance.OnDataMinigamesGetted += GetAllMinigames;
        CallMinigameController.Instance.OnDataUserMinigameStatsByMinigameGetted += GetUserMinigameStatsByMinigame;
    }

    public void SelectMinigame(int index)
    {
        selectedMinigameIndex = index;

        SetMinigameData();

        CallMinigameController.Instance.GetUserMinigameStatsByMinigameData(minigames[index].Id);
    }

    public void UpdateMinigame()
    {
        Minigames minigame = new Minigames()
        {
            Id = minigames[selectedMinigameIndex].Id,
            Name = nameText.text,
            CreationDate = minigames[selectedMinigameIndex].CreationDate,
            Description = descriptionText.text,
            ScoreToUnlock = int.Parse(scoreToUnlockText.text)
        };
        CallMinigameController.Instance.UpdateMinigamesData(minigame);
    }
}
