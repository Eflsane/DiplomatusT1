using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    public string prefUserName = "CosmopediaSysUserName";

    public void goBack() 
    {
        SceneManager.LoadScene(1);
    }

    public void goToGames()
    {
        SceneManager.LoadScene(3);
    }

    public void goToMap()
    {
        SceneManager.LoadScene(2);
    }

    public void goToLibra()
    {
        SceneManager.LoadScene(4);
    }
    public void goToSpaceShooter()
    {
        SceneManager.LoadScene(6);
    }
    public void goToSpaceKabinet()
    {
        SceneManager.LoadScene(5);
    }
}
