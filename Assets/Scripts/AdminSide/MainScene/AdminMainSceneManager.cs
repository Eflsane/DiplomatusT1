using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminMainSceneManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI aNAME;
    // Start is called before the first frame update
    void Start()
    {
        aNAME.text = AdminDataManager.Instance.AName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
