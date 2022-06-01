using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class AdminsDTO : MonoBehaviour
{
    public static AdminsDTO Instance { get; private set; }

    public string dataURL = string.Empty;

    //public event Action<List<AdminsWithout>> OnGetAllAdminsSuccess = (List<AdminsWithout> dbAdminsWithout) => { };
    public event Action<AdminsWithout> OnGetAdminSuccess = (AdminsWithout dbAdminsWithout) => { };
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetAdmin(string adminName)
    {
        Debug.Log("startGettingUsrData");
        StartCoroutine(GetAdminCoroutine(adminName));
    }

    private IEnumerator GetAdminCoroutine(string adminName)
    {
        UnityWebRequest request = new UnityWebRequest($"{dataURL}/{adminName}", "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        AdminsWithout adminsWithout = Newtonsoft.Json.JsonConvert.DeserializeObject<AdminsWithout>(request.downloadHandler.text);
        Debug.Log(adminsWithout.RegisterDate);

        OnGetAdminSuccess?.Invoke(adminsWithout);
    }
}
