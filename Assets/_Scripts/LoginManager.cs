using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public GameObject login, fillPlayerName, privacySetting, loading;
    public TextMeshProUGUI inputPlayerName, placeholder;
    public TMP_InputField nameInputField;

    private void Awake()
    {
        inputPlayerName.text = "";
        nameInputField.onEndEdit.AddListener(ValidateNameInput);
    }
    public void Login()
    {
        login.SetActive(false);
        fillPlayerName.SetActive(true);
    }

    public void Next()
    {
        if (inputPlayerName.text.Length > 3)
        {
            placeholder.text = "超過3個字元";
            nameInputField.text = "";
            inputPlayerName.text = "";
        }
        else if (inputPlayerName.text == null)
        {
            placeholder.text = "請輸入暱稱";
            nameInputField.text = "";
            inputPlayerName.text = "";
        }
        else if (inputPlayerName.text.Length == 1 || inputPlayerName.text.Length == 2 || inputPlayerName.text.Length == 3 && inputPlayerName.text != null)
        {
            DialogManager.playerName = inputPlayerName.text;
            fillPlayerName.SetActive(false);
            privacySetting.SetActive(true);
        }
    }

    public void ValidateNameInput(string inputText)
    {
        // Check if the input field is empty or contains only whitespace
        if (string.IsNullOrWhiteSpace(inputText))
        {
            placeholder.text = "請輸入暱稱";
        }
        else
        {
            DialogManager.playerName = inputPlayerName.text;
            fillPlayerName.SetActive(false);
            privacySetting.SetActive(true);
        }
    }

    public void Finished()
    {
        privacySetting.SetActive(false);
        loading.SetActive(true);
        StartCoroutine(WelcomeToEcho());
    }

    IEnumerator WelcomeToEcho()
    {
        yield return new WaitForSeconds(4f);
        //loading.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
}
