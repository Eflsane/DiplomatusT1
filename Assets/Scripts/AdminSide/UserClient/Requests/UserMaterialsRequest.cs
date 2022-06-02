using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UserMaterialsRequest : MonoBehaviour
{
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
        username = PlayerPrefs.GetString(manager.prefUserName);

        UsersWithoutDTO.Instance.OnGetUserSuccess += FinishGettingData;
        UsersWithoutDTO.Instance.GetUser(username);

        UserOpennedMaterialDTO.Instance.OnGetUserOpennedMaterialsByUserSuccess += FinishGettingUserMatsData;
        //MinigamesDTO.Instance.OnGetAllMinigamesSuccess += FinishGettingMinigamesData;

    }

    private void FinishGettingData(UsersWithout user)
    {
        avatars[(int)(user.AvatarID - 1)].gameObject.SetActive(true);
        usernameText.text = user.Username;
        coinzText.text = user.Coinz.ToString();
        coinz = user.Coinz;

        UserMinigameStatsDTO.Instance.GetUserMinigameStatsByUser(username);
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
            closedMats[(int)mat.MaterialId - 1].SetActive(false);
            openedMats[(int)mat.MaterialId - 1].SetActive(true);
        }
    }

    public void OpenMaterial(double price,  GameObject opennededMaterial, GameObject closedMaterial)
    {
        if(coinz >= price)
        {
            UsersWithoutDTO.Instance.UpdateUserCoinz(new UsersWithout()
            {
                Username = username,
                Coinz = coinz - price,
            });

            opennededMaterial.SetActive(true);
            closedMaterial.SetActive(false);
        }
    }
}
