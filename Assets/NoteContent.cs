using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class NoteContent : MonoBehaviour, IPointerClickHandler
{
    public GameObject browserTitle, browserContent;

    public int browserContentNum;

    public GameObject findBrowserTitle, findBrowserContent, noteCanvas;

    public bool haveSearched = false;

    private void Start()
    {
        findBrowserTitle = FindObjectOfType<Browser>().gameObject.transform.GetChild(0).
                           transform.GetChild(0).transform.GetChild(0).gameObject;
        findBrowserContent = FindObjectOfType<Browser>().gameObject.transform.GetChild(1).
                             gameObject;
        noteCanvas = FindObjectOfType<Note>().gameObject;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int index = TMP_TextUtilities.FindIntersectingLink(gameObject.GetComponent<TextMeshProUGUI>(), Input.mousePosition, Camera.main);

        Debug.Log(index);

        if (index > -1)
        {
            if (!haveSearched)
            {
                GameObject title = Instantiate(browserTitle, findBrowserTitle.transform);
                GameObject content = Instantiate(browserContent, findBrowserContent.transform);
                title.GetComponent<BrowserTitleValue>().content = content;
                //markButton.GetComponent<InputButtonValue>().browserContent = content;
                haveSearched = true;
                FindObjectOfType<Browser>().browserList.Add(content);
                browserContentNum = FindObjectOfType<Browser>().browserList.Count - 1;
                findBrowserTitle.GetComponent<RectTransform>().sizeDelta += new Vector2(0, 564);
            }
            if (!MenuManager.canClickBrowser)
            {
                MenuManager.canClickBrowser = true;
            }
            //functionBox_ani.SetTrigger("isDisappear");
            noteCanvas.transform.GetChild(2).gameObject.SetActive(true);
            FindObjectOfType<Browser>().browserList[browserContentNum].SetActive(true);
            for(int i=0;i< FindObjectOfType<Browser>().browserList.Count;i++)
            {
                if(i!=browserContentNum)
                {
                    FindObjectOfType<Browser>().browserList[i].SetActive(false);
                }
            }
            StartCoroutine(FindObjectOfType<News>().Searching());
        }
    }
}
