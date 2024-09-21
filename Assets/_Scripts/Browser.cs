using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Browser : MonoBehaviour
{
    public static Browser instance = null;
    public List<GameObject> browserList;
    public Button markButton, saveNoteButton;
    public GameObject browserTitle, browserContent, savedSuccessfullyImage, noteText, noteCollection, searchingFaildImage;

    public Animator functionBox_ani;
    bool canSearch;
    public string noteContent;
    //bool canSaveNote;
    public GameObject searchingImage;

    public GameObject noteCanvas;
    public GameObject findBrowserTitle, findBrowserContent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            MenuManager.browserCanvas = gameObject;
           // instance.GetComponent<Canvas>().worldCamera = FindObjectOfType<Camera>();
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

    #region 點擊mark時會發生的事件
    public void HaveSavedNote_ClickMark(Button button)  //取得Button、顯示FunctionBox
    {
        //bool haveSaved = button.GetComponent<InputButtonValue>().haveSaved;
        markButton = button;

        if (button.GetComponent<InputButtonValue>().haveSaved == false)
        {
            saveNoteButton.interactable = true;
            functionBox_ani.SetTrigger("isShow");

        }
        else
        {
            saveNoteButton.interactable = false;
            functionBox_ani.SetTrigger("isShow");
        }
    }

    public void SaveNoteContent_ClickMark(string _noteContent)  //儲存Mark裡的文字
    {
        noteContent = _noteContent;
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
        functionBox_ani.SetTrigger("isDisappear");
        savedSuccessfullyImage.SetActive(true);
        StartCoroutine(SavedSuccessfully());

        GameObject note = Instantiate(noteText, noteCollection.transform);
        TextMeshProUGUI text = note.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        text.text = noteContent;
    }
    #endregion

    public void ClickSearchingInBrowser()
    {
        if (!markButton.GetComponent<InputButtonValue>().haveSearched && canSearch)
        {
            GameObject title = Instantiate(browserTitle, findBrowserTitle.transform);
            GameObject content = Instantiate(browserContent, findBrowserContent.transform);
            title.GetComponent<BrowserTitleValue>().content = content;
            markButton.GetComponent<InputButtonValue>().browserContent = content;
            markButton.GetComponent<InputButtonValue>().haveSearched = true;
            FindObjectOfType<Browser>().browserList.Add(content);
            markButton.GetComponent<InputButtonValue>().browserContentNum = FindObjectOfType<Browser>().browserList.Count - 1;
        }

        functionBox_ani.SetTrigger("isDisappear");
        searchingImage.SetActive(true);
        StartCoroutine(Searching());
    }


    IEnumerator Searching()
    {

        yield return new WaitForSeconds(2f);
        searchingImage.SetActive(false);

        if (!canSearch)
        {
            searchingFaildImage.SetActive(true);
            StartCoroutine(SearchingFaild());
        }
        if (canSearch)
        {
            //newsCanvas.SetActive(false);
            BrowserBackButton.sceneNum_browser = 1;
            FindObjectOfType<Browser>().browserList[markButton.GetComponent<InputButtonValue>().browserContentNum].SetActive(true);
            findBrowserContent.SetActive(true);
            // SceneManager.LoadScene("Browser");
        }

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

}
