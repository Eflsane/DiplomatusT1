using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenControllerAdm : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(Screen.resolutions[Screen.resolutions.Length - 1].width, Screen.resolutions[Screen.resolutions.Length - 1].height, FullScreenMode.Windowed);
        

        Debug.Log(Screen.currentResolution);
        Debug.Log(Screen.dpi);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
