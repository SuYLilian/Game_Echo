using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{

    public static DialogManager instance = null;

    public GameObject dialogPanel, lingYin, chatBox;
    public Sprite[] lingYinImages;


    public float touchDelay = 1f, countUp;
    public bool canInputTouch;
    public float typeSpeed = 0.05f;
    public bool isDialog = false;
    public int dialogIndex;

    public bool canType = false;
    public List<string> sentences;
    public TextMeshProUGUI textDisplay, nameFrameText;
    public static string playerName;

    public int gameLevel = 0;
    public string prompt;

    public GameObject mailTitleGroup;

    //public GameObject transitionImage;
    public Animator animator;
    public TextMeshProUGUI endText;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            //instance.GetComponent<Canvas>().worldCamera = FindObjectOfType<Camera>();
        }

        else if (instance != this)
        {
            //instance.GetComponent<Canvas>().worldCamera = FindObjectOfType<Camera>();
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(gameObject);
        nameFrameText.text = playerName;
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

    void Update()
    {
        ClickScreen_Dialog();
    }

    void EventOrder()
    {
        switch (dialogIndex)
        {
            case 0:
                dialogIndex = 1;                
                StartCoroutine(Type());
                break;
            case 1:
                isDialog = false;
                dialogPanel.SetActive(false);
                chatBox.SetActive(false);
                for (int i = 0; i < mailTitleGroup.transform.childCount; i++)
                {
                    mailTitleGroup.transform.GetChild(i).GetComponent<Button>().enabled = true;
                }
                dialogIndex = 2;
                break;
            case 2:
                dialogIndex = 3;
                StartCoroutine(Type());
                break;
            case 3:
                isDialog = false;
                dialogPanel.SetActive(false);
                chatBox.SetActive(false);
                FindObjectOfType<MailManager>().link.enabled = true;
                dialogIndex = 4;
                break;
            case 4:
                FindObjectOfType<AudioManager>().gameObject.GetComponent<AudioSource>().clip= FindObjectOfType<AudioManager>().bgmClips[1];
                FindObjectOfType<AudioManager>().audioSource.Play();
                lingYin.SetActive(true);
                nameFrameText.text = "玲音";
                dialogIndex = 5;
                StartCoroutine(Type());
                break;
            case 5:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 6;
                StartCoroutine(Type());
                break;
            case 6:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[1];
                nameFrameText.text = "玲音";
                dialogIndex = 7;
                StartCoroutine(Type());
                break;
            case 7:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 8;
                StartCoroutine(Type());
                break;
            case 8:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                nameFrameText.text = "玲音";
                dialogIndex = 9;
                StartCoroutine(Type());
                break;
            case 9:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 10;
                StartCoroutine(Type());
                break;
            case 10:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[2];
                nameFrameText.text = "玲音";
                dialogIndex = 11;
                StartCoroutine(Type());
                break;
            case 11:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 12;
                StartCoroutine(Type());
                break;
            case 12:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                nameFrameText.text = "玲音";
                dialogIndex = 13;
                sentences[dialogIndex] = "正確，保羅所下達的指令為在他死後協助 "+playerName+" 調查出真正的原因，所以您必須有所行動。";
                StartCoroutine(Type());
                break;
            case 13:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 14;
                StartCoroutine(Type());
                break;
            case 14:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 15;
                StartCoroutine(Type());
                break;
            case 15:
                FindObjectOfType<AudioManager>().gameObject.GetComponent<AudioSource>().clip = FindObjectOfType<AudioManager>().bgmClips[2];
                FindObjectOfType<AudioManager>().audioSource.Play();
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[3];
                nameFrameText.text = "玲音";
                dialogIndex = 16;
                StartCoroutine(Type());
                break;
            case 16:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 17;
                StartCoroutine(Type());
                break;
            case 17:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                nameFrameText.text = "玲音";
                dialogIndex = 18;
                StartCoroutine(Type());
                break;
            case 18:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 19;
                StartCoroutine(Type());
                break;
            case 19:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[4];
                nameFrameText.text = "玲音";
                dialogIndex = 20;
                sentences[dialogIndex] = "抱歉玲音無法做到，指令的內容為玲音需要協助 "+playerName+" 調查，所以您需要親自調查保羅的死因。";
                StartCoroutine(Type());
                break;
            case 20:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 21;
                StartCoroutine(Type());
                break;
            case 21:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[5];
                nameFrameText.text = "玲音";
                dialogIndex = 22;
                StartCoroutine(Type());
                break;
            case 22:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 23;
                StartCoroutine(Type());
                break;
            case 23:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[6];
                nameFrameText.text = "玲音";
                dialogIndex = 24;
                StartCoroutine(Type());
                break;
            case 24:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 25;
                StartCoroutine(Type());
                break;
            case 25:
                FindObjectOfType<AudioManager>().gameObject.GetComponent<AudioSource>().clip = FindObjectOfType<AudioManager>().bgmClips[1];
                FindObjectOfType<AudioManager>().audioSource.Play();
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[2];
                nameFrameText.text = "玲音";
                dialogIndex = 26;
                StartCoroutine(Type());
                break;
            case 26:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 27;
                StartCoroutine(Type());
                break;
            case 27:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[7];
                nameFrameText.text = "玲音";
                dialogIndex = 28;
                StartCoroutine(Type());
                break;
            case 28:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 29;
                StartCoroutine(Type());
                break;
            case 29:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                nameFrameText.text = "玲音";
                dialogIndex = 30;
                StartCoroutine(Type());
                break;
            case 30:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 31;
                StartCoroutine(Type());
                break;
            case 31:
                FadeOut();
                isDialog = false;
                //dialogPanel.SetActive(false);
                //chatBox.SetActive(false);
                //lingYin.SetActive(false);
                dialogIndex = 32;
                MailManager.isEnd_dialog_01 = true;
                MenuManager.canShowInforamtion_mail = false;
                MenuManager.canShowInformation_news = true;
                MenuManager.date = "03/05";
                MenuManager.day = "星期四";
                //SceneManager.LoadScene("Menu");
                break;
            case 32:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                //lingYin.SetActive(true);
                nameFrameText.text = playerName;
                dialogIndex = 33;
                StartCoroutine(Type());
                break;
            case 33:                
                nameFrameText.text = "";
                dialogIndex = 87;                
                StartCoroutine(Type());
                break;
            case 87:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[7];
                lingYin.SetActive(true);
                nameFrameText.text = "玲音";
                dialogIndex = 34;
                sentences[dialogIndex] = "早安， "+playerName+" 。";
                StartCoroutine(Type());
                break;
            case 34:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 35;
                StartCoroutine(Type());
                break;
            case 35:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                nameFrameText.text = "玲音";
                dialogIndex = 36;
                StartCoroutine(Type());
                break;
            case 36:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 37;
                StartCoroutine(Type());
                break;
            case 37:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                nameFrameText.text = "玲音";
                dialogIndex = 38;
                StartCoroutine(Type());
                break;
            case 38:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 39;
                StartCoroutine(Type());
                break;
            case 39:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[6];
                nameFrameText.text = "玲音";
                dialogIndex = 40;
                StartCoroutine(Type());
                break;
            case 40:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 41;
                StartCoroutine(Type());
                break;
            case 41:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                nameFrameText.text = "玲音";
                dialogIndex = 42;
                StartCoroutine(Type());
                break;
            case 42:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 43;
                StartCoroutine(Type());
                break;
            case 43:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[8];
                nameFrameText.text = "玲音";
                dialogIndex = 44;
                StartCoroutine(Type());
                break;
            case 44:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 45;
                StartCoroutine(Type());
                break;
            case 45:
                FindObjectOfType<AudioManager>().gameObject.GetComponent<AudioSource>().clip = FindObjectOfType<AudioManager>().bgmClips[0];
                FindObjectOfType<AudioManager>().audioSource.Play();
                isDialog = false;
                dialogPanel.SetActive(false);
                chatBox.SetActive(false);
                lingYin.SetActive(false);
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[7];
                nameFrameText.text = "玲音";
                dialogIndex = 46;
                sentences[dialogIndex] = "做得很好， "+playerName+" 。";
                break;
            case 46:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 47;
                StartCoroutine(Type());
                break;
            case 47:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 48;
                StartCoroutine(Type());
                break;
            case 48:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[1];
                nameFrameText.text = "玲音";
                dialogIndex = 49;
                StartCoroutine(Type());
                break;
            case 49:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 50;
                StartCoroutine(Type());
                break;
            case 50:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[9];
                nameFrameText.text = "玲音";
                dialogIndex = 51;
                StartCoroutine(Type());
                break;
            case 51:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 52;
                StartCoroutine(Type());
                break;
            case 52:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[3];
                nameFrameText.text = "玲音";
                dialogIndex = 53;
                StartCoroutine(Type());
                break;
            case 53:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 54;
                StartCoroutine(Type());
                break;
            case 54:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[4];
                nameFrameText.text = "玲音";
                dialogIndex = 55;
                StartCoroutine(Type());
                break;
            case 55:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 56;
                StartCoroutine(Type());
                break;
            case 56:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[10];
                nameFrameText.text = "玲音";
                dialogIndex = 57;
                StartCoroutine(Type());
                break;
            case 57:
                FadeOut();
                MenuManager.date = "03/06";
                MenuManager.day = "星期五";
                //SceneManager.LoadScene("Menu");
                FindObjectOfType<AudioManager>().gameObject.GetComponent<AudioSource>().clip = FindObjectOfType<AudioManager>().bgmClips[0];
                FindObjectOfType<AudioManager>().audioSource.Play();
                isDialog = false;
                //dialogPanel.SetActive(false);
                //chatBox.SetActive(false);
                //lingYin.SetActive(false);
                dialogIndex = 88;
                break;
            case 88:
                lingYin.GetComponent<Image>().sprite = lingYinImages[7];
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.SetActive(true);
                lingYin.SetActive(true);
                nameFrameText.text = "玲音";
                dialogIndex = 58;
                sentences[dialogIndex] = "午安 "+playerName+" 。";
                StartCoroutine(Type());
                break;
            case 58:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);               
                nameFrameText.text = playerName;
                dialogIndex = 59;
                StartCoroutine(Type());
                break;
            case 59:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                nameFrameText.text = "玲音";
                dialogIndex = 60;
                StartCoroutine(Type());
                break;
            case 60:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 61;
                StartCoroutine(Type());
                break;
            case 61:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[1];
                nameFrameText.text = "玲音";
                dialogIndex = 62;
                StartCoroutine(Type());
                break;
            case 62:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[7];
                nameFrameText.text = "玲音";
                dialogIndex = 63;
                sentences[dialogIndex] = "但玲音收到的指令是協助 "+playerName+" 調查保羅的死因。";
                StartCoroutine(Type());
                break;
            case 63:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 64;
                StartCoroutine(Type());
                break;
            case 64:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[5];
                nameFrameText.text = "玲音";
                dialogIndex = 65;
                StartCoroutine(Type());
                break;
            case 65:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 66;
                StartCoroutine(Type());
                break;
            case 66:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 67;
                StartCoroutine(Type());
                break;
            case 67:
                nameFrameText.text = "";
                dialogIndex = 89;
                sentences[dialogIndex] = playerName + " 此時盯著玲音的樣子好一會。";
                StartCoroutine(Type());
                break;
            case 89:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[1];
                nameFrameText.text = "玲音";
                dialogIndex = 68;
                StartCoroutine(Type());
                break;
            case 68:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 69;
                StartCoroutine(Type());
                break;
            case 69:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[7];
                nameFrameText.text = "玲音";
                dialogIndex = 70;
                StartCoroutine(Type());
                break;
            case 70:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[1];
                nameFrameText.text = "玲音";
                dialogIndex = 71;
                StartCoroutine(Type());
                break;
            case 71:
                FindObjectOfType<AudioManager>().gameObject.GetComponent<AudioSource>().clip = FindObjectOfType<AudioManager>().bgmClips[0];
                FindObjectOfType<AudioManager>().audioSource.Play();
                isDialog = false;
                dialogIndex = 72;
                dialogPanel.SetActive(false);
                chatBox.SetActive(false);
                lingYin.SetActive(false);
                break;
            case 72:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.SetActive(true);
                nameFrameText.text = "玲音";
                dialogIndex = 73;
                StartCoroutine(Type());
                break;
            case 73:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 74;
                StartCoroutine(Type());
                break;
            case 74:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[7];
                nameFrameText.text = "玲音";
                dialogIndex = 75;
                StartCoroutine(Type());
                break;
            case 75:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 76;
                StartCoroutine(Type());
                break;
            case 76:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[1];
                nameFrameText.text = "玲音";
                dialogIndex = 77;
                StartCoroutine(Type());
                break;
            case 77:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 78;
                StartCoroutine(Type());
                break;
            case 78:
                nameFrameText.text = "";
                dialogIndex = 90;
                sentences[dialogIndex]= playerName+ " 攤開雙手，詢問玲音的狀況";
                StartCoroutine(Type());
                break;
            case 90:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[7];
                nameFrameText.text = "玲音";
                dialogIndex = 79;
                StartCoroutine(Type());
                break;
            case 79:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 80;
                StartCoroutine(Type());
                break;
            case 80:
                nameFrameText.text = "";
                dialogIndex = 91;
                StartCoroutine(Type());
                break;
            case 91:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 81;
                StartCoroutine(Type());
                break;
            case 81:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                nameFrameText.text = "玲音";
                dialogIndex = 82;
                StartCoroutine(Type());
                break;
            case 82:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 83;
                StartCoroutine(Type());
                break;
            case 83:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                nameFrameText.text = "玲音";
                dialogIndex = 84;
                StartCoroutine(Type());
                break;
            case 84:
                lingYin.GetComponent<Image>().color = new Color(0.17f, 0.17f, 0.17f, 1);
                nameFrameText.text = playerName;
                dialogIndex = 85;
                StartCoroutine(Type());
                break;
            case 85:
                lingYin.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                lingYin.GetComponent<Image>().sprite = lingYinImages[3];
                nameFrameText.text = "玲音";
                dialogIndex = 86;
                StartCoroutine(Type());
                break;
            case 86:
                animator.SetTrigger("FadeOut_End");
                FindObjectOfType<AudioManager>().gameObject.GetComponent<AudioSource>().clip = FindObjectOfType<AudioManager>().bgmClips[0];
                FindObjectOfType<AudioManager>().audioSource.Play();
                isDialog = false;
                dialogIndex = 87;
                /*SceneManager.LoadScene("Menu");
                dialogPanel.SetActive(false);
                chatBox.SetActive(false);
                lingYin.SetActive(false);*/
                break;




        }
    }
    void ClickScreen_Dialog()
    {
        countUp += Time.deltaTime;
        if (countUp >= touchDelay)
        {
            canInputTouch = true;
            countUp = 0;
        }

        if (Input.touchCount == 1 && isDialog && canInputTouch)
        {
            if (textDisplay.text == sentences[dialogIndex])
            {
                EventOrder();
                canInputTouch = false;
            }
            else if (textDisplay.text != sentences[dialogIndex])
            {
                StopAllCoroutines();
                textDisplay.text = sentences[dialogIndex];
                canInputTouch = false;
                //index++;
                // EventOder();
            }
        }

        /*countUp += Time.deltaTime;
        if (countUp >= 1f)
        {
            canInputTouch = true;
            countUp = 0;
        }
        if (Input.touchCount == 1 && isDialog && canInputTouch)
        {
               StopAllCoroutines();
               EventOrder();
               canInputTouch = false;
            
          
        }*/

        else if (Input.touchCount == 1 && MenuManager.isPrompt && canInputTouch)
        {
            if (textDisplay.text == prompt)
            {
                Debug.Log(111);
                canInputTouch = false;
                MenuManager.isPrompt = false;
                dialogPanel.SetActive(false);
                chatBox.SetActive(false);
                lingYin.SetActive(false);
                textDisplay.text = "";
                FindObjectOfType<MenuManager>().commentButton.enabled = true;
            }
           /* else if (textDisplay.text != prompt)
            {
                Debug.Log(222);
                textDisplay.text="";
                StopAllCoroutines();
                textDisplay.text = prompt;
                canInputTouch = false;
                //index++;
                // EventOder();
            }*/
        }
    }

    public void FadeIn()
    {
        SceneManager.LoadScene("Menu");
        lingYin.SetActive(false);
        textDisplay.text = "";
        animator.SetTrigger("FadeIn");
    }
    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }

   /* public void FadeOut_End()
    {
        animator.SetTrigger("FadeOut_End");
    }*/

    public void StartType_End()
    {
        StartCoroutine(Type_End());
    }

    public void StartType()
    {
        StartCoroutine(Type());
    }

    public IEnumerator Type_End()
    {
        string endString = "體驗版到此結束感謝您的遊玩";
        foreach (char letter in endString)
        {
            endText.text += letter;
            yield return new WaitForSeconds(typeSpeed);

        }
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu");
        dialogPanel.SetActive(false);
        chatBox.SetActive(false);
        lingYin.SetActive(false);
        animator.SetTrigger("FadeIn_End");
    }

    public IEnumerator Type()
    {

        textDisplay.text = "";
       

        if (!MenuManager.isPrompt)
        {
           
            foreach (char letter in sentences[dialogIndex].ToCharArray())
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(typeSpeed);
               
            }

            if (!isDialog)
            {
                canInputTouch = false;
                countUp = 0;
                isDialog = true;
            }

        }

        if (MenuManager.isPrompt)
        {
           
            canInputTouch = false;
            countUp = 0;
            Debug.Log(333);
            foreach (char letter in prompt.ToCharArray())
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(typeSpeed);
              
            }
            
                //canInputTouch = false;
                //countUp = 0;

        }

       

    }


}
