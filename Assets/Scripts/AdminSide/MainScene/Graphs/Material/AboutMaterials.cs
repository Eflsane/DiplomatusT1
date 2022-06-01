using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AboutMaterials : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown materialsDropdown;
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
    //[SerializeField]
    //private MonoColorBarChart scoreChart;
    [SerializeField]
    private MonoColorBarChart timechart;

    private UsersWithout currentUser;
    private List<Materials> materials;
    private List<UserOpennedMaterial> userOpennedMaterialByMaterials;

    private int selectedMaterialIndex = -1;

    public TMP_Dropdown MaterialsDropdown { get => materialsDropdown; private set => materialsDropdown = value; }
    public List<TextMeshProUGUI> ParamsList { get => paramsList; private set => paramsList = value; }
    public UsersWithout CurrentUser { get => currentUser; private set => currentUser = value; }
    public List<Materials> Materials { get => materials; private set => materials = value; }
    public List<UserOpennedMaterial> UserOpennedMaterials { get => userOpennedMaterialByMaterials; private set => userOpennedMaterialByMaterials = value; }

    // Start is called before the first frame update
    void Start()
    {
        LoadMaterials();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GetAllMaterials(List<Materials> materials)
    {
        this.Materials = materials;

        SetMaterialsDropdown();
    }

    private void SetMaterialsDropdown()
    {
        MaterialsDropdown.options.Clear();
        foreach (var material in Materials)
        {
            MaterialsDropdown.options.Add(new TMP_Dropdown.OptionData($"{material.Id} - {material.Name}"));
        }
    }

    private void GetUserOpennedMaterialsByMaterial(List<UserOpennedMaterial> userOpennedMaterials)
    {
        this.UserOpennedMaterials = userOpennedMaterials;

        SetUsersMinigameData();

        //scoreChart.GetComponentInChildren<CallMonoColorBarChartMinigameScore>().GetData(MinigamesStatsByMinigame);
        timechart.GetComponentInChildren<CallMonoColorBarChartMaterialTime>().GetData(UserOpennedMaterials);
    }

    private void SetMaterialData()
    {
        idText.text = Materials[selectedMaterialIndex].Id.ToString();
        nameText.text = Materials[selectedMaterialIndex].Name;
        creationDateText.text = Materials[selectedMaterialIndex].CreationDate.ToShortDateString();
        scoreToUnlockText.text = Materials[selectedMaterialIndex].ScoreToUnlock.ToString();
        descriptionText.text = Materials[selectedMaterialIndex].Description;
    }

    private void SetUsersMinigameData()
    {
        ParamsList[0].text = UserOpennedMaterials.Count.ToString();

        /*float midTime = 0.0f;
        float midScore = 0.0f;
        foreach (var userMaterial in UserOpennedMaterials)
        {
            midTime += (float)(userMaterial.EndTime - userMaterial.BeginTime).TotalSeconds;
            midScore += (float)userMaterial.OpenningDate;
        }
        midTime = midTime / (float)MinigamesStatsByMinigame.Count;
        midScore = midScore / (float)MinigamesStatsByMinigame.Count;
        ParamsList[1].text = $"{Mathf.FloorToInt(midTime / 60).ToString("0")}:{Mathf.FloorToInt(midTime % 60).ToString("0")}";
        ParamsList[2].text = midScore.ToString("0.0");*/

        //ParamsList[4].text = MinigamesStatsByMinigame.Max(x => x.UserScore).ToString();
        //ParamsList[5].text = MinigamesStatsByMinigame.Min(x => x.UserScore).ToString();
    }

    private void LoadMaterials()
    {
        CallMaterialController.Instance.OnDataMaterialsGetted += GetAllMaterials;
        CallMaterialController.Instance.OnDataUserOpennedMaterialsByMaterialGetted += GetUserOpennedMaterialsByMaterial;
    }

    public void SelectMaterial(int index)
    {
        selectedMaterialIndex = index;

        SetMaterialData();

        CallMaterialController.Instance.GetUserOpennedMaterialsByMaterialData(Materials[index].Id);
    }

    public void UpdateMaterials()
    {
        Materials materials = new Materials()
        {
            Id = Materials[selectedMaterialIndex].Id,
            Name = nameText.text,
            CreationDate = Materials[selectedMaterialIndex].CreationDate,
            Description = descriptionText.text,
            ScoreToUnlock = int.Parse(scoreToUnlockText.text)
        };
        CallMaterialController.Instance.UpdateMaterialsData(materials);
    }
}
