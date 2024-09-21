using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrowserBackButton : MonoBehaviour
{
    public static int sceneNum_browser=0;
    public GameObject browserMenu, browserContent,noteCanvas,newsContentRangement,backButton_news,newsMenu;
    public Animator functionBox_ani;
    public static bool isFromNewsContentEnter = false;
    public static bool isFromNewsMenuEnter = false;


    private void Awake()
    {
        Note.instance.canShowOnScreen = true;
        noteCanvas = GameObject.Find("NoteCanvas");

        backButton_news = GameObject.Find("NewsCanvas").transform.GetChild(2).gameObject;
        newsContentRangement = GameObject.Find("NewsCanvas").transform.GetChild(1).gameObject;
        browserMenu = GameObject.Find("BrowserCanvas").transform.GetChild(0).gameObject;
        browserContent = GameObject.Find("BrowserCanvas").transform.GetChild(1).gameObject;
        functionBox_ani = GameObject.Find("NewsCanvas").transform.GetChild(3).GetComponent<Animator>();
        newsMenu = FindObjectOfType<News>().gameObject.transform.GetChild(0).gameObject;

    }

    public void BackButton_Browser()
    {
        if(sceneNum_browser==1)
        {
            if (isFromNewsContentEnter)
            {
                //isFromNewsContentEnter = false;
                for (int i = 0; i < browserContent.transform.childCount; i++)
                {
                    browserContent.transform.GetChild(i).gameObject.SetActive(false);
                }
                sceneNum_browser = 0;
                browserContent.SetActive(false);
                backButton_news.SetActive(true);
                functionBox_ani.SetTrigger("isDisappear");
                newsContentRangement.transform.GetChild(News.instance.openedNewsContentNum).gameObject.SetActive(true);
                newsContentRangement.SetActive(true);
                SceneManager.LoadScene("News");
                
            }
            else if (isFromNewsMenuEnter)
            {
                //isFromNewsContentEnter = false;
                for (int i = 0; i < browserContent.transform.childCount; i++)
                {
                    browserContent.transform.GetChild(i).gameObject.SetActive(false);
                }
                sceneNum_browser = 0;
                browserContent.SetActive(false);
                backButton_news.SetActive(true);
                functionBox_ani.SetTrigger("isDisappear");
                newsMenu.SetActive(true);
                SceneManager.LoadScene("News");
                
                //newsContentRangement.transform.GetChild(News.instance.openedNewsContentNum).gameObject.SetActive(true);
                //newsContentRangement.SetActive(true);
            }
            else
            {
                for (int i = 0; i < browserContent.transform.childCount; i++)
                {
                    browserContent.transform.GetChild(i).gameObject.SetActive(false);
                }
                sceneNum_browser = 0;
                browserContent.SetActive(false);
                browserMenu.SetActive(true);
                functionBox_ani.SetTrigger("isDisappear");
            }
        }

        else if(sceneNum_browser==0)
        {

           
                Note.instance.canShowOnScreen = false;
                noteCanvas.transform.GetChild(1).gameObject.SetActive(false);
                browserMenu.SetActive(false);
                SceneManager.LoadScene("Menu");

        }
    }
}
