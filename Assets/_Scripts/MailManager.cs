using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MailManager : MonoBehaviour
{
    public static bool haveClickedLink=false;
    public Button link;
    public GameObject mailTitle, mailContent, titleGroup;

    public GameObject installPanel,whiteLight;
    public Image installFilled;
    public TextMeshProUGUI installText;
    public float installSpeed;
    public float transparencySpeed;

    bool isInstalling = false;
   // bool isShowing_whiteLight = false;
    public static bool isEnd_dialog_01 = false;

    public GameObject noteCanvas;

    public Animator animator_mail;

    int sceneNum_mail=0;

    private void Awake()
    {
        DialogManager.instance.mailTitleGroup = titleGroup;

        if(MenuManager.havewClickedNews_first)
        {
            noteCanvas = GameObject.Find("NoteCanvas");
            Note.instance.canShowOnScreen = true;

        }


        if (!haveClickedLink)
        {
            link.enabled = true;
        }
        else if(haveClickedLink)
        {
            link.enabled = false;
        }

        if(DialogManager.instance.dialogIndex==0)
        {
            for(int i=0;i<titleGroup.transform.childCount;i++)
            {
                titleGroup.transform.GetChild(i).GetComponent<Button>().enabled = false;
            }
            link.enabled = false;
            StartCoroutine(WaitDialog());
        }
    }

    private void Update()
    {
        if(isInstalling)
        {
            installFilled.fillAmount += (installSpeed * Time.deltaTime) / 100;
            if(installFilled.fillAmount>=1)
            {
                isInstalling = false;
                installText.text = "安裝成功";
                StartCoroutine(Install());
            }
        }
        /*if(isShowing_whiteLight)
        {
            whiteLight.GetComponent<Image>().color += new Color(0, 0, 0, transparencySpeed * Time.deltaTime);
            if(whiteLight.GetComponent<Image>().color.a>=1)
            {
                transparencySpeed *= -1;
            }
            else if(whiteLight.GetComponent<Image>().color.a <= 0)
            {
                isShowing_whiteLight = false;
                whiteLight.SetActive(false);
                DialogManager.instance.dialogPanel.SetActive(true);
                DialogManager.instance.chatBox.SetActive(true);
                StartCoroutine(DialogManager.instance.Type());
                DialogManager.instance.isDialog = true;
                DialogManager.instance.textDisplay.text = DialogManager.instance.sentences[DialogManager.instance.dialogIndex];
            }
        }*/
    }

    public void AfterWhiteLightDisappear()
    {
        DialogManager.instance.dialogPanel.SetActive(true);
        DialogManager.instance.chatBox.SetActive(true);
        StartCoroutine(DialogManager.instance.Type());
    }

    public void ClickMailTitle(GameObject content)
    {
        sceneNum_mail = 1;
        content.SetActive(true);
        mailTitle.SetActive(false);
        if(DialogManager.instance.dialogIndex==2)
        {
            StartCoroutine(WaitDialog());
        }
    }

    public void BackButton_Mail()
    {
        if(sceneNum_mail==0)
        {
            if (isEnd_dialog_01)
            {
                if(MenuManager.havewClickedNews_first)
                {
                    Note.instance.canShowOnScreen = false;
                    noteCanvas.transform.GetChild(1).gameObject.SetActive(false);
                }

                SceneManager.LoadScene("Menu");
            }
        }
        else if(sceneNum_mail==1)
        {
            if (isEnd_dialog_01)
            {
                sceneNum_mail = 0;

                for (int i = 0; i < mailContent.transform.childCount; i++)
                {
                    mailContent.transform.GetChild(i).gameObject.SetActive(false);
                }
                mailTitle.SetActive(true);
            }            
        }
    }

    public void ClickLink()
    {
        haveClickedLink = true;
        installPanel.SetActive(true);
        isInstalling = true;
        link.enabled = false;
    }

    IEnumerator Install()
    {
        yield return new WaitForSeconds(1f);
        installPanel.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        animator_mail.SetTrigger("ShowWhiteLight");
        //whiteLight.SetActive(true);
        //isShowing_whiteLight = true;
    }

    IEnumerator WaitDialog()
    {
        yield return new WaitForSeconds(1.5f);
        DialogManager.instance.chatBox.SetActive(true);
        DialogManager.instance.dialogPanel.SetActive(true);
        //DialogManager.instance.lingYin.SetActive(true);
        StartCoroutine(DialogManager.instance.Type());
        //DialogManager.instance.isDialog = true;
        //DialogManager.instance.textDisplay.text = DialogManager.instance.sentences[DialogManager.instance.dialogIndex];
    }
}
