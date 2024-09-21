using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrowserTitleValue : MonoBehaviour
{
   public GameObject content, browserContent;


    private void Awake()
    {
        browserContent = GameObject.Find("BrowserCanvas").transform.GetChild(1).gameObject;

    }

    public void OpenContent()
    {
        BrowserBackButton.sceneNum_browser = 1;
        content.SetActive(true);
        browserContent.SetActive(true);
    }
}
