using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CommentManager : MonoBehaviour
{
    public List<CommentScriptable> comments;
    public List<string> commentCollection;

    int orderNum_correct, orderNum_error;
    int randomFrame, randomComment;
    int[] errorQuantity, correctQuantity;
    int r;

    public GameObject[] commentFrames;
    public GameObject[] collectionFrames;
    public GameObject commentScrollGroup, caculation, restartButton, collectionGroup;
    public GameObject continueButton, retryButton;
    Vector2 commentGroupSize_original;

    public int collectionNum_all, collectionNum_correct;
    public TextMeshProUGUI allCollection_text, wrongCollection_text, missingCollection_text;

    bool haveShowCaculation = false;

    //public static int level = 0;

    public GameObject noteButton;
    public GameObject noteCanvas;

    public static bool isFirstEnterComment = true;
    public bool isTeaching;
    public GameObject teachingImage;
    public Sprite[] teachingSprite;
    public int teachingSprite_num=0;
    public GameObject teachingButton;

    public GameObject greenRedLight;

    public GameObject confirmPanel;

    float touchDelay_comment = 1, countUp_comment;
    bool canInputTouch_comment;

    

    void Awake()
    {

        if (isFirstEnterComment)
        {
            teachingImage.SetActive(true);
            isTeaching = true;
            isFirstEnterComment = false;
        }
        Note.instance.canShowOnScreen = true;
        noteButton = GameObject.Find("NoteCanvas").transform.GetChild(1).gameObject;
        orderNum_correct = comments[DialogManager.instance.gameLevel].comments_correct.Count;
        orderNum_error = comments[DialogManager.instance.gameLevel].comments_error.Count;
        commentGroupSize_original = commentScrollGroup.GetComponent<RectTransform>().sizeDelta;
        CommentGenerate();

    }

    // Update is called once per frame
    void Update()
    {
        if (commentScrollGroup.transform.childCount == 0 && !haveShowCaculation)
        {
            ShowCaculation();
            Debug.Log("ru,7");

        }

        Teaching();
    }

    public void CommentGenerate()
    {
        Debug.Log("ru,6");

        correctQuantity = new int[orderNum_correct];
        errorQuantity = new int[orderNum_error];

        commentScrollGroup.GetComponent<RectTransform>().sizeDelta += new Vector2(0, 312.4f * (orderNum_correct + orderNum_error) + 97.468f);

        int orderCorrect = 0;
        int orderError = 0;

        randomFrame = Random.Range(0, 2);

        for (int i = 0; i < orderNum_correct; i++)
        {
            r = Random.Range(0, orderNum_correct);
            correctQuantity[i] = r;

            for (int j = 0; j < i; j++)
            {
                while (correctQuantity[i] == correctQuantity[j])
                {
                    r = Random.Range(0, orderNum_correct);
                    correctQuantity[i] = r;
                    j = 0;
                }
            }
        }

        for (int i = 0; i < orderNum_error; i++)
        {
            r = Random.Range(0, orderNum_error);
            errorQuantity[i] = r;

            for (int j = 0; j < i; j++)
            {
                while (errorQuantity[i] == errorQuantity[j])
                {
                    r = Random.Range(0, orderNum_error);
                    errorQuantity[i] = r;
                    j = 0;
                }
            }
        }

        for (int i = 0; i < (orderNum_correct + orderNum_error); i++)
        {
            Debug.Log(orderCorrect + "，" + orderError + "/" + (orderNum_correct + orderNum_error));

            if (randomFrame == 0)
            {
                randomFrame = 1;

                if (orderCorrect < orderNum_correct && orderError < orderNum_error)
                {

                    randomComment = Random.Range(0, 2);// 0是correct，1是error

                    if (randomComment == 0)
                    {
                        GameObject comment = Instantiate(commentFrames[0], commentScrollGroup.transform);
                        Debug.Log("22");
                        TextMeshProUGUI text = comment.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                        text.text = comments[DialogManager.instance.gameLevel].comments_correct[correctQuantity[orderCorrect]];
                        comment.tag = "Correct";
                        orderCorrect++;


                    }
                    else if (randomComment == 1)
                    {
                        GameObject comment = Instantiate(commentFrames[0], commentScrollGroup.transform);
                        TextMeshProUGUI text = comment.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                        text.text = comments[DialogManager.instance.gameLevel].comments_error[errorQuantity[orderError]];
                        comment.tag = "Error";
                        orderError++;


                    }
                }
                else if (orderCorrect >= orderNum_correct && orderError < orderNum_error)
                {
                    GameObject comment = Instantiate(commentFrames[0], commentScrollGroup.transform);
                    TextMeshProUGUI text = comment.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                    text.text = comments[DialogManager.instance.gameLevel].comments_error[errorQuantity[orderError]];
                    comment.tag = "Error";
                    orderError++;

                }

                else if (orderError >= orderNum_error && orderCorrect < orderNum_correct)
                {
                    GameObject comment = Instantiate(commentFrames[0], commentScrollGroup.transform);
                    TextMeshProUGUI text = comment.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                    text.text = comments[DialogManager.instance.gameLevel].comments_correct[correctQuantity[orderCorrect]];
                    comment.tag = "Correct";
                    orderCorrect++;

                }


            }

            else if (randomFrame == 1)
            {
                randomFrame = 0;

                if (orderCorrect < orderNum_correct && orderError < orderNum_error)
                {

                    randomComment = Random.Range(0, 2);// 0是correct，1是error

                    if (randomComment == 0)
                    {
                        GameObject comment = Instantiate(commentFrames[1], commentScrollGroup.transform);
                        TextMeshProUGUI text = comment.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                        text.text = comments[DialogManager.instance.gameLevel].comments_correct[correctQuantity[orderCorrect]];
                        comment.tag = "Correct";
                        orderCorrect++;

                    }
                    else if (randomComment == 1)
                    {
                        GameObject comment = Instantiate(commentFrames[1], commentScrollGroup.transform);
                        TextMeshProUGUI text = comment.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                        text.text = comments[DialogManager.instance.gameLevel].comments_error[errorQuantity[orderError]];
                        comment.tag = "Error";
                        orderError++;

                    }
                }
                else if (orderCorrect >= orderNum_correct && orderError < orderNum_error)
                {
                    GameObject comment = Instantiate(commentFrames[1], commentScrollGroup.transform);
                    TextMeshProUGUI text = comment.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                    text.text = comments[DialogManager.instance.gameLevel].comments_error[errorQuantity[orderError]];
                    comment.tag = "Error";
                    orderError++;

                }

                else if (orderError >= orderNum_error && orderCorrect < orderNum_correct)
                {
                    GameObject comment = Instantiate(commentFrames[1], commentScrollGroup.transform);
                    TextMeshProUGUI text = comment.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                    text.text = comments[DialogManager.instance.gameLevel].comments_correct[correctQuantity[orderCorrect]];
                    comment.tag = "Correct";
                    orderCorrect++;

                }
            }

        }

        haveShowCaculation = false;
    }

    public void ConfirmRestartButton()
    {
        commentScrollGroup.transform.parent.gameObject.SetActive(true);
        commentScrollGroup.transform.GetComponent<RectTransform>().sizeDelta = commentGroupSize_original;
        collectionNum_all = 0;
        collectionNum_correct = 0;
        commentCollection.Clear();
        for (int i = 0; i < collectionGroup.transform.childCount; i++)
        {
            Destroy(collectionGroup.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < commentScrollGroup.transform.childCount; i++)
        {
            Destroy(commentScrollGroup.transform.GetChild(i).gameObject);
        }

        CommentGenerate();
        confirmPanel.SetActive(false);

    }

    public void RestartButton()
    {
        confirmPanel.SetActive(true);
    }

    public void CloseConfirmPanel()
    {
        confirmPanel.SetActive(false);
    }

    void ShowCaculation()
    {
        haveShowCaculation = true;
        collectionGroup.GetComponent<RectTransform>().sizeDelta = new Vector2(1017.7f, 399.872f * (collectionNum_all));
        for (int i = 0; i < commentCollection.Count; i++)
        {
            if (randomFrame == 0)
            {
                randomFrame = 1;
                GameObject collection = Instantiate(collectionFrames[0], collectionGroup.transform);
                collection.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = commentCollection[i];
                //text.text = commentCollection[i];
            }
            else if (randomFrame == 1)
            {
                randomFrame = 0;
                GameObject collection = Instantiate(collectionFrames[1], collectionGroup.transform);
                collection.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = commentCollection[i];
                //text.text = commentCollection[i];
            }
        }
        //allCollection_text.text = collectionNum_all.ToString();
        //correctCollection_text.text = collectionNum_correct.ToString();
        wrongCollection_text.text = (collectionNum_all - collectionNum_correct).ToString();
        if (collectionNum_correct > orderNum_correct)
        {
            missingCollection_text.text = "0";
        }
        else
        {
            missingCollection_text.text = (orderNum_correct - collectionNum_correct).ToString();
        }

        commentScrollGroup.transform.parent.gameObject.SetActive(false);
        restartButton.SetActive(false);
        teachingButton.SetActive(false);

        if (collectionNum_all == orderNum_correct && collectionNum_all == collectionNum_correct)
        {
            continueButton.SetActive(true);
            //MenuManager.canShowInformation_comment = false;
            retryButton.SetActive(false);
        }
        else
        {
            continueButton.SetActive(false);
            retryButton.SetActive(true);
        }
        greenRedLight.SetActive(false);
        caculation.SetActive(true);
    }

    public void ContinueButton()
    {
        if (DialogManager.instance.dialogIndex == 46)
        {
            FindObjectOfType<AudioManager>().gameObject.GetComponent<AudioSource>().clip = FindObjectOfType<AudioManager>().bgmClips[1];
            FindObjectOfType<AudioManager>().audioSource.Play();
            DialogManager.instance.dialogPanel.SetActive(true);
            DialogManager.instance.chatBox.SetActive(true);
            DialogManager.instance.lingYin.SetActive(true);
            StartCoroutine(DialogManager.instance.Type());
            //DialogManager.instance.textDisplay.text = DialogManager.instance.sentences[DialogManager.instance.dialogIndex];
            //DialogManager.instance.isDialog = true;
            Browser.instance.browserList.Clear();
            for (int i = 0; i < News.instance.findBrowserTitle.transform.childCount; i++)
            {
                Destroy(News.instance.findBrowserTitle.transform.GetChild(i).gameObject);
            }
            News.instance.findBrowserTitle.GetComponent<RectTransform>().sizeDelta 
            = new Vector2(News.instance.findBrowserTitle.GetComponent<RectTransform>().sizeDelta.x, 50);
            for (int i = 0; i < News.instance.findBrowserContent.transform.childCount; i++)
            {
                Destroy(News.instance.findBrowserContent.transform.GetChild(i).gameObject);
            }           
            for(int i=0;i<News.instance.newsItems_01.Length;i++)//刪除第一關newsTitle
            {
                Destroy(News.instance.newsItems_01[i]);
            }
            for(int i=0;i<News.instance.newsItems_02.Length;i++)//顯示第二關newsTitle
            {
                News.instance.newsItems_02[i].SetActive(true);
            }
            for(int i=0;i< News.instance.noteCollection.transform.childCount;i++)
            {
                Destroy(News.instance.noteCollection.transform.GetChild(i).gameObject);
            }
            News.instance.noteCollection.GetComponent<RectTransform>().sizeDelta
            = new Vector2(News.instance.noteCollection.GetComponent<RectTransform>().sizeDelta.x, 100);
            News.instance.newsTitle.GetComponent<RectTransform>().sizeDelta               //60(Top+Bottom),30(間距)
            = new Vector2(News.instance.newsTitle.GetComponent<RectTransform>().sizeDelta.x, 60+ 807.0248f * 4+30*3);
            MenuManager.newsInformationNum = "4";
            MenuManager.canShowInformation_news = true;
            MenuManager.canEnterComment = false;
            DialogManager.instance.gameLevel = 1;
            MenuManager.canShowInformation_comment = false;
            Note.instance.canShowOnScreen = false;
            noteButton.SetActive(false);

        }
        else if (DialogManager.instance.dialogIndex == 72)
        {
            FindObjectOfType<AudioManager>().gameObject.GetComponent<AudioSource>().clip = FindObjectOfType<AudioManager>().bgmClips[2];
            FindObjectOfType<AudioManager>().audioSource.Play();
            DialogManager.instance.nameFrameText.text = DialogManager.playerName;
            DialogManager.instance.dialogPanel.SetActive(true);
            DialogManager.instance.chatBox.SetActive(true);
            DialogManager.instance.textDisplay.text = DialogManager.instance.sentences[DialogManager.instance.dialogIndex];
            StartCoroutine(DialogManager.instance.Type());
            //DialogManager.instance.isDialog = true;
            //MenuManager.canEnterComment = false;
            Note.instance.canShowOnScreen = false;
            noteButton.SetActive(false);
            MenuManager.canShowInformation_comment = false;
        }
        else
        {
            Note.instance.canShowOnScreen = false;
            noteButton.SetActive(false);
            SceneManager.LoadScene("Menu");
        }
        
    }

    public void RetryButton()
    {
        commentScrollGroup.transform.parent.gameObject.SetActive(true);
        restartButton.SetActive(true);
        teachingButton.SetActive(true);
        commentScrollGroup.transform.GetComponent<RectTransform>().sizeDelta = commentGroupSize_original;
        collectionNum_all = 0;
        collectionNum_correct = 0;
        commentCollection.Clear();

        for (int i = 0; i < collectionGroup.transform.childCount; i++)
        {
            Destroy(collectionGroup.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < commentScrollGroup.transform.childCount; i++)
        {
            Destroy(commentScrollGroup.transform.GetChild(i).gameObject);
        }
        greenRedLight.SetActive(true);
        CommentGenerate();
        caculation.SetActive(false);
    }

    public void BackButton_Comment()
    {
        Note.instance.canShowOnScreen = false;
        noteButton.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    void Teaching()
    {
        countUp_comment += Time.deltaTime;
        if (countUp_comment >= touchDelay_comment)
        {
            canInputTouch_comment = true;
            countUp_comment = 0;
        }

        /*if (countUp_comment >= 1f)
        {
            canInputTouch_comment = true;
            countUp_comment = 0;
        }*/

        if (isTeaching && Input.touchCount==1 && canInputTouch_comment)
        {
            if(teachingSprite_num<teachingSprite.Length-1)
            {
                teachingSprite_num++;
                teachingImage.GetComponent<Image>().sprite = teachingSprite[teachingSprite_num];
                canInputTouch_comment = false;
            }
            else
            {
                isTeaching = false;
                teachingImage.SetActive(false);
                teachingSprite_num = 0;
                teachingImage.GetComponent<Image>().sprite = teachingSprite[teachingSprite_num];
                canInputTouch_comment = false;
            }
        }
    }

    public void CloseTeaching()
    {
        isTeaching = false;
        teachingImage.SetActive(false);
        teachingSprite_num = 0;
        teachingImage.GetComponent<Image>().sprite = teachingSprite[teachingSprite_num];
    }

    public void ShowTeaching()
    {
        teachingImage.SetActive(true);
        isTeaching = true;
    }
}

