using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserRegisterRequest : MonoBehaviour
{
    [SerializeField]
    private InputField usernameText;
    [SerializeField]
    private InputField passText;
    [SerializeField]
    private InputField emailText;
    [SerializeField]
    private InputField dateOfBirthText;
    [SerializeField]
    private InputField sexText;
    

    [SerializeField]
    public GameObject loginPanel;
    [SerializeField]
    public Button playButton;

    private int avatarID = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectAvatar(int avatar)
    {
        avatarID = avatar;
    }

    public void StartReg()
    {
        if (usernameText.text.Length > 0 && passText.text.Length > 0 && emailText.text.Length > 0 &&
            dateOfBirthText.text.Length > 0 && sexText.text.Length > 0  && avatarID > 0)
        {
            Users user = new Users()
            {
                Username = usernameText.text,
                Password = passText.text,
                Email = emailText.text,
                DateOfBirth = DateTime.ParseExact(dateOfBirthText.text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture),
                Gender = sexText.text == "ж" ? 1 : 2,
                AvatarID = avatarID,
                Coinz = 150
            };

            UsersWithoutLoginDTO.Instance.OnRegUserSuccess += FinishReg;
            UsersWithoutLoginDTO.Instance.UserReg(user);
        }

    }

    private void FinishReg(UsersWithout userWithout)
    {
        GoBack manager = GetComponentInParent<GoBack>();
        PlayerPrefs.SetString(manager.prefUserName, userWithout.Username);

        playButton.gameObject.SetActive(true);
        loginPanel.gameObject.SetActive(false);
    }
}
