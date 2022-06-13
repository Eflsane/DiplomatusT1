using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionAddPanel : MonoBehaviour
{
    public TMPro.TextMeshProUGUI qNum;
    public TMPro.TMP_InputField qText;

    public int AnswersCount { get => transform.childCount; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Delete()
    {
        Destroy(gameObject);

        GetComponentInParent<AboutAddQuests>().questionAddPanels.Remove(this);
        GetComponentInParent<AboutAddQuests>().RefreshQuestsNums();
    }
}
