using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrowserContentValue : MonoBehaviour
{
    //public string notentContent;
    //public Button markButton;
    //public GameObject browserTitle, browserContent;

    public GameObject browserCanvas,newsCanvas;
    public Button saveNoteButton ;
    public Animator functionBox_ani;

    private void Awake()
    {
        browserCanvas = GameObject.Find("BrowserCanvas");
        newsCanvas= GameObject.Find("NewsCanvas");
        functionBox_ani = newsCanvas.transform.GetChild(3).gameObject.GetComponent<Animator>();
        saveNoteButton = functionBox_ani.gameObject.transform.GetChild(0).GetComponent<Button>();

        //browserCanvas.transform.childCount(2)
    }

    public void ReturnBrowserContentText(string _noteContent)
    {
        //newsCanvas.GetComponent<News>().noteContent = _noteContent;


    }

    public void ReturnMarkButton(Button button)
    {
        newsCanvas.GetComponent<News>().markButton = button;
        if (button.GetComponent<InputButtonValue>().haveSaved == false)
        {
            saveNoteButton.interactable = true;
            //button.GetComponent<InputButtonValue>().haveSaved = true;
            functionBox_ani.SetTrigger("isShow");

        }
        else
        {
            saveNoteButton.interactable = false;
            functionBox_ani.SetTrigger("isShow");
        }
    }

    public void ReturnBrowserTitle(GameObject _browserTitle)
    {
        if (_browserTitle.name != "Zoom")
        {
            newsCanvas.GetComponent<News>().browserTitle = _browserTitle;
            newsCanvas.GetComponent<News>().canSearch = true;
        }
        else if (_browserTitle.name == "Zoom")
        {
            newsCanvas.GetComponent<News>().canSearch = false;
        }
    }

    public void ReturnBrowserContent(GameObject _browserContent)
    {
        if (_browserContent.name != "Zoom")
        {
            newsCanvas.GetComponent<News>().browserContent = _browserContent;
            newsCanvas.GetComponent<News>().canSearch = true;
        }
        else if (_browserContent.name == "Zoom")
        {
            newsCanvas.GetComponent<News>().canSearch = false;
        }
    }

    public void HaveSavedNote_ClickMark(Button button)  //取得Button、顯示FunctionBox
    {
        //bool haveSaved = button.GetComponent<InputButtonValue>().haveSaved;
        newsCanvas.GetComponent<News>().markButton = button;

        Image[] images = button.gameObject.GetComponentsInChildren<Image>();

        button.interactable = false;

        for (int i = 1; i < images.Length; i++)
        {
            images[i].color = new Color(0.5943396f, 0.5943396f, 0.5943396f, 0.4039216f);
        }


        /*if (button.GetComponent<InputButtonValue>().haveSaved == false)
        {
            saveNoteButton.interactable = true;
            functionBox_ani.SetTrigger("isShow");

        }
        else if (button.GetComponent<InputButtonValue>().haveSaved == true)
        {
            saveNoteButton.interactable = false;
            functionBox_ani.SetTrigger("isShow");
        }*/
    }

    public void SaveNoteContentForward_ClickMark(string _noteContent_forward)  //儲存Mark裡的文字
    {
        News.instance.noteContent_forward = _noteContent_forward;
    }

    public void SaveNoteLinkWord_ClickMark(string _noteLinkWord)  //儲存Mark裡的文字
    {
        News.instance.noteLinkWord = "<link=https://www.youtube.com/watch?v=zRsX5S9ndvI&t=6s>" + _noteLinkWord;
    }

    public void SaveNoteContentBack_ClickMark(string _noteContent_back)  //儲存Mark裡的文字
    {
        News.instance.noteContent_back = _noteContent_back;
    }

    public void SaveNoteTitle_ClickMark(string _noteTitle)
    {
        News.instance.noteTitle = _noteTitle;
        News.instance.ClickSaveNoteButton();//儲存筆記
    }

    public void SaveRelatedWebsiteTitle_ClickMark(GameObject _browserTitle)  //儲存Mark對應的BrowserTitle
    {
        if (_browserTitle.name != "Zoom")
        {
            News.instance.browserTitle = _browserTitle;
            News.instance.canSearch = true;
        }
        else if (_browserTitle.name == "Zoom")
        {
            News.instance.canSearch = false;
        }
    }

    public void SaveRelatedWebsiteContent_ClickMark(GameObject _browserContent)  //儲存Mark對應的BrowserContent
    {
        if (_browserContent.name != "Zoom")
        {
            News.instance.browserContent = _browserContent;
            News.instance.canSearch = true;
        }
        else if (_browserContent.name == "Zoom")
        {
            News.instance.canSearch = false;
        }
    }
}
