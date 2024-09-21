using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
public class MenuManager : MonoBehaviour
{
    public static GameObject newsCanvas, browserCanvas, noteCanvas;
    public static bool haveSaveGameObject = false;
    //public static bool canClickBrowserApp = false;
    public Button browserApp, newsApp, commentApp, noteApp;
    public GameObject informationNum_mail, informationNum_news, information_comment;
    public static bool havewClickedNews_first = false;
    public static bool canEnterComment = false;
    public static bool isPrompt = false;
    public Button commentButton;

    public GameObject fakeNote, realNotePanel, realNoteButton;

    public Slider seSlider, bgmSlider;
    public AudioMixer audioMixer;
    public static float seValue = 20, bgmValue;

    public GameObject settingPanel;

    public static bool canClickBrowser = false, canClickNote = false;
    public static bool canShowInformation_comment = false;
    public static bool canShowInformation_news = false;
    public static bool canShowInforamtion_mail = true;

    public TextMeshProUGUI newsImformation_text;
    public static string newsInformationNum="2";
    
    public GameObject prologuePanel;
    public TextMeshProUGUI prologueText;
    public float typeSpeed = 0.05f;
    public List<string> sentences_prologue;
    public int prologueIndex;
    public float touchDelay_prologue = 1f, countUp_prologue;
    public bool canInputTouch_prologue;
    public bool isPrologue = false;
    public GameObject prologue_tri;

    public TextMeshProUGUI dateText, dayText;
    public static string date="03/04", day="�P���T";

    private void Awake()
    {
        dateText.text = date;
        dayText.text = day;

        bgmSlider.value = bgmValue;
        seSlider.value = seValue;
        newsImformation_text.text = newsInformationNum;

        if (havewClickedNews_first)
        {
            noteCanvas = GameObject.Find("NoteCanvas");
            realNoteButton = noteCanvas.transform.GetChild(1).gameObject;
            realNotePanel = noteCanvas.transform.GetChild(0).gameObject;
        }

        if (!canShowInforamtion_mail)
        {
            informationNum_mail.SetActive(false);
        }

        if (canShowInformation_news)
        {
            informationNum_news.SetActive(true);
        }

        if (!MailManager.isEnd_dialog_01)
        {
            sentences_prologue[prologueIndex] = "�G�뤭���ɡAECHO���o�ͤF���Өƥ�A�õo�{���̬O " + DialogManager.playerName + " �������Où�C";
            prologuePanel.SetActive(true);
            StartCoroutine(Type_Prologue());
            isPrologue = true;
            newsApp.interactable = false;
            browserApp.interactable = false;
            commentApp.interactable = false;
            noteApp.interactable = false;
        }
        if (!canClickNote)
        {
            noteApp.interactable = false;
            commentApp.interactable = false;
        }
        if (!canClickBrowser)
        {
            browserApp.interactable = false;
        }
        if (canShowInformation_comment)
        {
            information_comment.SetActive(true);
        }


    }

    private void Start()
    {
        if (DialogManager.instance.dialogIndex == 32)
        {
            
            //DialogManager.instance.dialogPanel.SetActive(true);
            //DialogManager.instance.chatBox.SetActive(true);
            //StartCoroutine(DialogManager.instance.Type());
           // DialogManager.instance.isDialog = true;
            //DialogManager.instance.textDisplay.text = DialogManager.instance.sentences[DialogManager.instance.dialogIndex];
        }
        if (DialogManager.instance.dialogIndex == 88)
        {
            informationNum_news.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "4";
            FindObjectOfType<AudioManager>().gameObject.GetComponent<AudioSource>().clip = FindObjectOfType<AudioManager>().bgmClips[1];
            FindObjectOfType<AudioManager>().audioSource.Play();
           // DialogManager.instance.dialogPanel.SetActive(true);
           // DialogManager.instance.chatBox.SetActive(true);
            DialogManager.instance.nameFrameText.text = "";
            //StartCoroutine(DialogManager.instance.Type());
            //DialogManager.instance.isDialog = true;
            //DialogManager.instance.textDisplay.text = DialogManager.instance.sentences[DialogManager.instance.dialogIndex];
        }
    }

    private void Update()
    {
        ClickScreen_Prologue();
    }

    public void LoadScene(string sceneName)
    {
        if (havewClickedNews_first)
        {
            noteCanvas.transform.GetChild(1).gameObject.SetActive(true);
            Note.instance.canShowOnScreen = true;
        }

        if (sceneName == "News")
        {
            if (!havewClickedNews_first)
            {
                havewClickedNews_first = true;
            }
            canShowInformation_news = false;
            BrowserBackButton.isFromNewsMenuEnter = true;
        }

        if (haveSaveGameObject)
        {
            if (sceneName == "News")
            {
                for (int i = 0; i < newsCanvas.transform.GetChild(1).transform.childCount; i++)
                {
                    newsCanvas.transform.GetChild(1).transform.GetChild(i).gameObject.SetActive(false);
                }
                newsCanvas.transform.GetChild(0).gameObject.SetActive(true);
                newsCanvas.transform.GetChild(2).gameObject.SetActive(true);
                newsCanvas.SetActive(true);
                canShowInformation_news = false;
                BrowserBackButton.isFromNewsMenuEnter = true;

            }

            else if (sceneName == "Browser")
            {
                for (int i = 0; i < browserCanvas.transform.GetChild(1).transform.childCount; i++)
                {
                    browserCanvas.transform.GetChild(1).transform.GetChild(i).gameObject.SetActive(false);
                }
                browserCanvas.transform.GetChild(0).gameObject.SetActive(true);
                browserCanvas.SetActive(true);
            }
        }
        SceneManager.LoadScene(sceneName);

    }

    public void LoadScene_Comment(string sceneName)
    {


        if (!canEnterComment)
        {
            DialogManager.instance.dialogPanel.SetActive(true);
            DialogManager.instance.chatBox.SetActive(true);
            DialogManager.instance.nameFrameText.text = "�­�";
            DialogManager.instance.lingYin.GetComponent<Image>().sprite = DialogManager.instance.lingYinImages[1];
            DialogManager.instance.lingYin.SetActive(true);
            isPrompt = true;
            commentButton.enabled = false;
            StartCoroutine(DialogManager.instance.Type());
        }

        else if (canEnterComment)
        {
            noteCanvas.transform.GetChild(1).gameObject.SetActive(true);
            Note.instance.canShowOnScreen = true;
            SceneManager.LoadScene(sceneName);
        }
    }

    public void ClickNoteApp()
    {
        if (havewClickedNews_first)
        {
            realNoteButton.SetActive(true);
            realNotePanel.SetActive(true);
            FindObjectOfType<Note>().noteIsShow = true;
        }
        else if (!havewClickedNews_first)
        {
            fakeNote.SetActive(true);
        }
    }

    public void ClickFakeNote()
    {
        fakeNote.SetActive(false);
    }


    public void SetBgmVolume(float volume)
    {
        volume = bgmSlider.value;
        bgmValue = volume;
        audioMixer.SetFloat("BGMVolume", volume);
    }

    public void SetSoundEffectVolume(float volume)
    {
        volume = seSlider.value;
        seValue = volume;
        audioMixer.SetFloat("SoundEffectVolume", volume);
    }

    public void OpenSetting()
    {
        settingPanel.SetActive(true);
    }
    public void CloseSetting()
    {
        settingPanel.SetActive(false);
    }

    IEnumerator PrologueDissapear()
    {
        while (prologuePanel.GetComponent<Image>().color.a > 0)
        {
            prologuePanel.GetComponent<Image>().color -= new Color(0, 0, 0, 0.9f * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
            if (prologuePanel.GetComponent<Image>().color.a <= 0)
            {
                Destroy(prologuePanel);
            }
        }

    }

    public void EventOrder_Prologue()
    {
        switch (prologueIndex)
        {
            case 0:
                prologueIndex = 1;
                sentences_prologue[prologueIndex] = DialogManager.playerName + " ���M�ܾ_��A���ѩ�Où�ͫe�`�O�S�̧� " + DialogManager.playerName + " ���·СA�S�o�S�̤������Y�D�`�����C";
                StartCoroutine(Type_Prologue());
                break;
            case 1:
                prologueIndex = 2;
                sentences_prologue[prologueIndex] = "�ҥH " + DialogManager.playerName + " �����������èS���D�`�b�G�A�u�Ʊ�ӿ쪺�Ʊ����֧����C";
                StartCoroutine(Type_Prologue());
                break;
            case 2:
                prologueIndex = 3;
                StartCoroutine(Type_Prologue());
                break;
            case 3:
                prologueIndex = 4;
                sentences_prologue[prologueIndex] = "�M�ӴN�b�Y�@�ѡA " + DialogManager.playerName + " ��M����F�@�ʶl��K�K";
                StartCoroutine(Type_Prologue());
                break;
            case 4:
                isPrologue = false;
                prologueText.text = "";
                Destroy(prologue_tri);
                StartCoroutine(PrologueDissapear());
                break;
        }
    }

    void ClickScreen_Prologue()
    {
        countUp_prologue += Time.deltaTime;
        if (countUp_prologue >= touchDelay_prologue)
        {
            canInputTouch_prologue = true;
            countUp_prologue = 0;
        }

        if (Input.touchCount == 1 && isPrologue && canInputTouch_prologue)
        {
            if (prologueText.text == sentences_prologue[prologueIndex])
            {
                EventOrder_Prologue();
                canInputTouch_prologue = false;
            }
            else if (prologueText.text != sentences_prologue[prologueIndex])
            {
                StopAllCoroutines();
                prologueText.text = sentences_prologue[prologueIndex];
                canInputTouch_prologue = false;
            }
        }

       /* countUp_prologue += Time.deltaTime;
        if (countUp_prologue >= 1f)
        {
            canInputTouch_prologue = true;
            countUp_prologue = 0;
        }

        if (Input.touchCount == 1 && isPrologue && canInputTouch_prologue)
        {
            StopAllCoroutines();
            EventOrder_Prologue();
            canInputTouch_prologue = false;

           
        }*/
    }
    IEnumerator Type_Prologue()
    {
        prologueText.text = "";
        foreach (char letter in sentences_prologue[prologueIndex].ToCharArray())
        {
            prologueText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
}
