using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class News : MonoBehaviour
{
    public Image[] newsMark_0;
    public GameObject noteText, noteCollection;

    public GameObject[] newsItems_01;
    public GameObject[] newsItems_02;

    //bool canSaveNote;
    public string noteContent_forward, noteContent_back, noteLinkWord, noteTitle;
    string linkText = "<link=https://www.youtube.com/watch?v=zRsX5S9ndvI&t=6s>";
    public Animator functionBox_ani;

    public Button saveNoteButton;
    public Button markButton;

    public GameObject searchingImage, savedSuccessfullyImage, searchingFaildImage;

    public GameObject noteCanvas;

    public GameObject browserTitle, browserContent, newsCanvas;

    public GameObject findBrowserTitle, findBrowserContent;

    public GameObject newsMenu, newsContentRangement,browserMenu;
    public GameObject newsTitle;

    public bool canSearch = false;
    public static News instance = null;

    public static int sceneNum_news = 0;

    public int openedNewsContentNum;



    private void Awake()
    {
        //findBrowserContent = GameObject.Find("BrowseCanvas/BrowserContent");
        //findBrowserTitle = GameObject.Find("BrowseCanvas/BrowserMenu/ScrollFrame/BrowserTitle");

        if (instance == null)
        {
            instance = this;
            MenuManager.newsCanvas = gameObject;
            MenuManager.haveSaveGameObject = true;
            //instance.GetComponent<Canvas>().worldCamera = FindObjectOfType<Camera>();
            // MenuManager.canClickBrowserApp = true;
        }

        else if (instance != this)
        {
            //instance.GetComponent<Canvas>().worldCamera = FindObjectOfType<Camera>();
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;

        DontDestroyOnLoad(gameObject);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Get the camera in the new scene
        GameObject[] rootObjects = scene.GetRootGameObjects();
        foreach (GameObject obj in rootObjects)
        {
            Camera camera = obj.GetComponentInChildren<Camera>();
            if (camera != null)
            {
                instance.GetComponent<Canvas>().worldCamera = camera;
                break;
            }
        }
    }

    private void Start()
    {
        Note.instance.canShowOnScreen = true;

    }

    public void BackButton_News()
    {
        if (sceneNum_news == 0)
        {
            SceneManager.LoadScene("Menu");
            BrowserBackButton.isFromNewsMenuEnter = false;            
            noteCanvas.transform.GetChild(1).gameObject.SetActive(false);
            Note.instance.canShowOnScreen = false;
            newsMenu.SetActive(false);
            newsContentRangement.SetActive(false);
            newsCanvas.transform.GetChild(2).gameObject.SetActive(false);
        }
        if (sceneNum_news == 1)
        {
            for (int i = 0; i < newsContentRangement.transform.childCount; i++)
            {
                newsContentRangement.transform.GetChild(i).gameObject.SetActive(false);
            }
            sceneNum_news = 0;
            BrowserBackButton.isFromNewsMenuEnter = true;
            BrowserBackButton.isFromNewsContentEnter = false;
            //functionBox_ani.SetTrigger("isDisappear");
            newsMenu.SetActive(true);
        }
    }

    public void CilckNewsTitle(GameObject newsContent)  //點擊新聞標題
    {
        //openedNewsContent = newsContent;
        sceneNum_news = 1;
        newsMenu.SetActive(false);
        newsContent.SetActive(true);
        openedNewsContentNum = newsContent.transform.GetSiblingIndex();
        Debug.Log(openedNewsContentNum);
        newsContentRangement.SetActive(true);
        BrowserBackButton.isFromNewsContentEnter = true;
        BrowserBackButton.isFromNewsMenuEnter = false;

    }


    /*取消Button的interactable
    public void CancelInteratable(Button thisButton)
    {
        thisButton.interactable = false;
    }*/

    #region 改變Mark顏色
    /*public void ChangeMarkColor(int markNum)
    {
        if (markNum == 0)
        {
            for (int i = 0; i < 2; i++)
            {
                newsMark_0[i].color = new Color(1, 0.98f, 0.98f, 0.4039216f);
            }
        }

        else if (markNum == 1)
        {
            for (int i = 2; i < 5; i++)
            {
                newsMark_0[i].color = new Color(1, 0.98f, 0.98f, 0.4039216f);
            }
        }

        else if (markNum == 2)
        {
            for (int i = 6; i < 8; i++)
            {
                newsMark_0[i].color = new Color(1, 0.98f, 0.98f, 0.4039216f);
            }
        }
    }*/
    #endregion

    #region 點擊mark時會發生的事件
    public void HaveSavedNote_ClickMark(Button button)  //取得Button、顯示FunctionBox
    {
        //bool haveSaved = button.GetComponent<InputButtonValue>().haveSaved;
        markButton = button;

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
        noteContent_forward = _noteContent_forward;
    }

    public void SaveNoteLinkWord_ClickMark(string _noteLinkWord)  //儲存Mark裡的文字
    {
        noteLinkWord = "<link=https://www.youtube.com/watch?v=zRsX5S9ndvI&t=6s>" + _noteLinkWord;
    }

    public void SaveNoteContentBack_ClickMark(string _noteContent_back)  //儲存Mark裡的文字
    {
        noteContent_back = _noteContent_back;
    }

    public void SaveNoteTitle_ClickMark(string _noteTitle)
    {
        noteTitle = _noteTitle;
        ClickSaveNoteButton();//儲存筆記
    }

    public void SaveRelatedWebsiteTitle_ClickMark(GameObject _browserTitle)  //儲存Mark對應的BrowserTitle
    {
        if (_browserTitle.name != "Zoom")
        {
            browserTitle = _browserTitle;
            canSearch = true;
        }
        else if (_browserTitle.name == "Zoom")
        {
            canSearch = false;
        }
    }

    public void SaveRelatedWebsiteContent_ClickMark(GameObject _browserContent)  //儲存Mark對應的BrowserContent
    {
        if (_browserContent.name != "Zoom")
        {
            browserContent = _browserContent;
            canSearch = true;
        }
        else if (_browserContent.name == "Zoom")
        {
            canSearch = false;
        }
    }
    #endregion

    #region 點擊[儲存至筆記本]
    public void ClickSaveNoteButton()
    {
        markButton.GetComponent<InputButtonValue>().haveSaved = true;
        //functionBox_ani.SetTrigger("isDisappear");
        FindObjectOfType<SeManager>().PlayClip_SE(FindObjectOfType<SeManager>().seClips[0]);
        savedSuccessfullyImage.SetActive(true);
        Note.instance.haveCollectedNum[DialogManager.instance.gameLevel]++;
        if (Note.instance.haveCollectedNum[DialogManager.instance.gameLevel] == Note.instance.levelNoteCollectionNum[DialogManager.instance.gameLevel])
        {
            MenuManager.canEnterComment = true;
            MenuManager.canShowInformation_comment = true;
        }
        if (!MenuManager.canClickNote)
        {
            MenuManager.canClickNote = true;
        }
        StartCoroutine(SavedSuccessfully());

        GameObject note = Instantiate(noteText, noteCollection.transform);
        TextMeshProUGUI titleText = note.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI contentText = note.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        titleText.text = noteTitle;
        contentText.text = noteContent_forward + noteLinkWord + noteContent_back;

        noteCollection.GetComponent<RectTransform>().sizeDelta += new Vector2(0, 421.7f);
        contentText.GetComponent<NoteContent>().browserTitle = browserTitle;
        contentText.GetComponent<NoteContent>().browserContent = browserContent;

    }
    #endregion


    #region 點擊搜尋瀏覽器
    public void ClickSearchingInBrowser()
    {
        /*if (!markButton.GetComponent<InputButtonValue>().haveSearched)
        {*/
        GameObject title = Instantiate(browserTitle, findBrowserTitle.transform);
        GameObject content = Instantiate(browserContent, findBrowserContent.transform);
        title.GetComponent<BrowserTitleValue>().content = content;
        //markButton.GetComponent<InputButtonValue>().browserContent = content;
        markButton.GetComponent<InputButtonValue>().haveSearched = true;
        FindObjectOfType<Browser>().browserList.Add(content);
        markButton.GetComponent<InputButtonValue>().browserContentNum = FindObjectOfType<Browser>().browserList.Count - 1;
        findBrowserTitle.GetComponent<RectTransform>().sizeDelta += new Vector2(0, 564);
        //}
        if (!MenuManager.canClickBrowser)
        {
            MenuManager.canClickBrowser = true;
        }
        //functionBox_ani.SetTrigger("isDisappear");
        searchingImage.SetActive(true);
        StartCoroutine(Searching());

    }
    #endregion

    public IEnumerator Searching()
    {

        yield return new WaitForSeconds(0.75f);
        searchingImage.SetActive(false);

        /*if (!canSearch)
         {
             FindObjectOfType<SeManager>().PlayClip_SE(FindObjectOfType<SeManager>().seClips[1]);
             searchingFaildImage.SetActive(true);
             StartCoroutine(SearchingFaild());
         }*/
        /*if (canSearch)
        {*/
        FindObjectOfType<SeManager>().PlayClip_SE(FindObjectOfType<SeManager>().seClips[2]);
        newsMenu.SetActive(false);
        newsContentRangement.SetActive(false);
        browserMenu.SetActive(false);
        newsCanvas.transform.GetChild(2).gameObject.SetActive(false);
        
        BrowserBackButton.sceneNum_browser = 1;
        //FindObjectOfType<Browser>().browserList[markButton.GetComponent<InputButtonValue>().browserContentNum].SetActive(true);
        
        findBrowserContent.SetActive(true);
        //BrowserBackButton.isFromNewsContentEnter = true;
        noteCanvas.transform.GetChild(0).gameObject.SetActive(false);
        Note.instance.noteIsShow = false;
        Note.instance.canShowOnScreen = true;
        SceneManager.LoadScene("Browser");
        //}

    }

    IEnumerator SavedSuccessfully()
    {
        yield return new WaitForSeconds(1f);
        savedSuccessfullyImage.SetActive(false);
    }

    IEnumerator SearchingFaild()
    {
        yield return new WaitForSeconds(1f);
        searchingFaildImage.SetActive(false);
    }

    public void TestChangeScene()
    {
        SceneManager.LoadScene("Browser");
    }
}
