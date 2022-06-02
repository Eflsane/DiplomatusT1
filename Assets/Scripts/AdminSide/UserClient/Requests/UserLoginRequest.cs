using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserLoginRequest : MonoBehaviour
{
    [SerializeField]
    private InputField usernameText;
    [SerializeField]
    private InputField passText;

    [SerializeField]
    public GameObject loginPanel;
    [SerializeField]
    public Button playButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLogin()
    {
        if(usernameText.text.Length > 0 && passText.text.Length > 0)
        {
            Users user = new Users()
            {
                Username = usernameText.text,
                Password = passText.text
            };

            UsersWithoutLoginDTO.Instance.OnLogUserSuccess += FinishLogin;
            UsersWithoutLoginDTO.Instance.UserLogin(user);
        }
            
    }

    private void FinishLogin(UsersWithout userWithout)
    {
        GoBack manager = GetComponentInParent<GoBack>();
        PlayerPrefs.SetString(manager.prefUserName, userWithout.Username);

        playButton.gameObject.SetActive(true);
        loginPanel.gameObject.SetActive(false);
    }
}
