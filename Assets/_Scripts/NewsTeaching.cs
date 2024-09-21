using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsTeaching : MonoBehaviour
{
    float countUp_newsteaching;
    float touchDelay_newsteaching=1;

    public bool isTeaching_news=false;
    public GameObject teachingImage_news;
    public Sprite[] teachingSprite_news;
    public int teachingSprite_num_news = 0;

    //float touchDelay_comment = 1, countUp_comment;
    bool canInputTouch_news;
    public static bool isFirstEnterNews = true;
    private void Awake()
    {
        if(isFirstEnterNews)
        {
            isFirstEnterNews = false;
            isTeaching_news = true;
            teachingImage_news.SetActive(true);
        }
    }

    void Update()
    {
        Teaching();
    }

    public void CloseTeaching()
    {
        isTeaching_news = false;
        teachingImage_news.SetActive(false);
        teachingSprite_num_news = 0;
        teachingImage_news.GetComponent<Image>().sprite = teachingSprite_news[teachingSprite_num_news];
    }

    public void ShowTeaching()
    {
        teachingImage_news.SetActive(true);
        isTeaching_news = true;
    }

    public void Teaching()
    {
        countUp_newsteaching += Time.deltaTime;
        if (countUp_newsteaching >= touchDelay_newsteaching)
        {
            canInputTouch_news = true;
            countUp_newsteaching = 0;
        }

        /*if (countUp_newsteaching >= 1f)
        {
            canInputTouch_news = true;
            countUp_newsteaching = 0;
        }*/

        if (isTeaching_news && Input.touchCount == 1 && canInputTouch_news)
        {
            if (teachingSprite_num_news < teachingSprite_news.Length - 1)
            {
                teachingSprite_num_news++;
                teachingImage_news.GetComponent<Image>().sprite = teachingSprite_news[teachingSprite_num_news];
                canInputTouch_news = false;
            }
            else
            {
                isTeaching_news = false;
                teachingImage_news.SetActive(false);
                teachingSprite_num_news = 0;
                teachingImage_news.GetComponent<Image>().sprite = teachingSprite_news[teachingSprite_num_news];
                canInputTouch_news = false;
            }
        }
    }
}
