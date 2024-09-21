using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Note : MonoBehaviour
{
    public bool noteIsShow;
    public GameObject notePanel;
    public static Note instance = null;
    public Animator functionBox_ani;

    public List<int> levelNoteCollectionNum;
    public List<int> haveCollectedNum;

    public bool canShowOnScreen;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            MenuManager.noteCanvas = gameObject;
            //instance.GetComponent<Canvas>().worldCamera = FindObjectOfType<Camera>();
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

    #region ÂIÀ»µ§°O¥»
    public void NoteButton()
    {
        if (canShowOnScreen)
        {
            if (!noteIsShow)
            {
                functionBox_ani.SetTrigger("isDisappear");
                noteIsShow = true;
                notePanel.SetActive(true);
            }
            else if (noteIsShow)
            {
                noteIsShow = false;
                notePanel.SetActive(false);


            }
        }
        else if (!canShowOnScreen)
        {
            if (!noteIsShow)
            {
                functionBox_ani.SetTrigger("isDisappear");
                noteIsShow = true;
                notePanel.SetActive(true);
            }
            else if (noteIsShow)
            {
                noteIsShow = false;
                notePanel.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);


            }
        }
    }
    #endregion
}
