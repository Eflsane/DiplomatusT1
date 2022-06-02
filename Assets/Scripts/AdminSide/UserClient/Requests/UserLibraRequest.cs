using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserLibraRequest : MonoBehaviour
{
    [SerializeField]
    private List<Image> avatars;
    [SerializeField]
    private List<GameObject> LockedMaterials;

    [SerializeField]
    private Text usernameText;
    [SerializeField]
    private Text coinzText;

    private string username;
    private GoBack manager;

    private UsersWithout user;

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
    }

    private void FinishGettingData(UsersWithout user)
    {
        avatars[(int)(user.AvatarID - 1)].gameObject.SetActive(true);
        usernameText.text = user.Username;
        coinzText.text = user.Coinz.ToString();

        this.user = user;
    }

    public void SpentMoney(int amount)
    {

    }
}
