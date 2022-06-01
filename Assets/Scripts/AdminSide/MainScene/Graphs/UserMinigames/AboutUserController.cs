using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AboutUserController : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown usersDropdown;
    [SerializeField]
    private List<TMPro.TextMeshProUGUI> paramsList = new List<TMPro.TextMeshProUGUI>();

    private List<UsersWithout> usersWithout;
    private List<Genders> genders;
    private List<UserMinigameStats> minigamesStatsByUsers;

    private int selectedUserIndex = -1;

    //private CallUserMinigameContainer callUserMinigameContainer;

    public TMP_Dropdown UsersDropdown { get => usersDropdown; private set => usersDropdown = value; }
    public List<TextMeshProUGUI> ParamsList { get => paramsList; private set => paramsList = value; }

    public List<UsersWithout> UsersWithout { get => usersWithout; private set => usersWithout = value; }
    public List<Genders> Genders { get => genders; private set => genders = value; }
    public List<UserMinigameStats> MinigamesStatsByUsers { get => minigamesStatsByUsers; private set => minigamesStatsByUsers = value; }

    public UsersWithout GetCurrentUser { get => usersWithout[selectedUserIndex]; }

    public event Action<UsersWithout> OnUserSelected = (UsersWithout user) => { };


    // Start is called before the first frame update
    void Start()
    {
        //callUserMinigameContainer = GetComponentInParent<CallUserMinigameContainer>();
        LoadUsers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void LoadUsers(List<UsersWithout> usersWithout)
    {
        UsersDropdown.options.Clear();
        foreach (var user in usersWithout)
        {
            UsersDropdown.options.Add(new Dropdown.OptionData(user.Username));
        }
    }

    public void SelectUser(int index)
    {
        selectedUserIndex = index;

        List<UserMinigameStats> userMinigameStats = callUserMinigameContainer

        //paramsList[i].text = 
    }

    public void SelectionSet()
    {

    }*/
    

    private void GetAllUsers(List<UsersWithout> usersWithout)
    {
        this.UsersWithout = usersWithout;      
    }

    private void GetAllGenders(List<Genders> genders)
    {
        this.Genders = genders;
        SetUserDropdown();
    }

    private void SetUserDropdown()
    {
        UsersDropdown.options.Clear();
        foreach (var user in UsersWithout)
        {
            UsersDropdown.options.Add(new TMP_Dropdown.OptionData(user.Username));
        }
    }

    private void GetUserMinigameStatsByUser(List<UserMinigameStats> userMinigameStats)
    {
        this.MinigamesStatsByUsers = userMinigameStats;

        SetUserMinigamesData();
    }  

    private void SetUserData()
    {
        ParamsList[0].text = usersWithout[selectedUserIndex].Username;
        ParamsList[1].text = usersWithout[selectedUserIndex].Email;
        ParamsList[2].text = Genders[(int)usersWithout[selectedUserIndex].Gender - 1].Gender;
        ParamsList[3].text = (DateTime.Now.Year - usersWithout[selectedUserIndex].DateOfBirth.Year).ToString();
        ParamsList[4].text = (DateTime.Now- usersWithout[selectedUserIndex].RegisterDate).Days.ToString();
        ParamsList[6].text = usersWithout[selectedUserIndex].Coinz.ToString();
    }

    private void SetUserMinigamesData()
    {
        float totalScores = 0.0f;
        foreach (var stat in minigamesStatsByUsers)
        {
            totalScores += (float)stat.UserScore;
        }
        ParamsList[5].text = totalScores.ToString();
    }

    public void LoadUsers()
    {
        CallUserController.Instance.OnDataUsersGetted += GetAllUsers;
        CallUserController.Instance.OnDataGendersGetted += GetAllGenders;
        CallUserController.Instance.OnDataUserMinigameStatsByUserGetted += GetUserMinigameStatsByUser;
    }

    public void SelectUser(int index)
    {
        selectedUserIndex = index;

        SetUserData();

        CallUserController.Instance.GetUserMinigameStatsByUserData(usersWithout[index].Username);

        OnUserSelected?.Invoke(GetCurrentUser);
    }
}
