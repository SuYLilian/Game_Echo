using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriDes : MonoBehaviour
{
    Color32 originalcolor;
    Vector3 originalLocalScale;

    public delegate void Recycle(TriDes particle);
    public Recycle recycle;

    public bool isRecycle=false;

    /*void Start()
    {
        originalcolor = new Color32(1,1,1,1);
        originalLocalScale = new Vector3(1,1,1);

        if (tag == "T0")
        InvokeRepeating("des", 0.4f,0.003f);
        else
        InvokeRepeating("des2", 0.2f,0.003f);
    }*/

    public void AllDes()
    {
        /*GetComponent<SpriteRenderer>().color = originalcolor;
        transform.localScale = originalLocalScale;*/
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        transform.localScale = new Vector3(1, 1, 1);

        if (tag == "T0")
            InvokeRepeating("des", 0.4f, 0.003f);
        else
            InvokeRepeating("des2", 0.2f, 0.003f);
    }
    public void des()
    {
        GetComponent<SpriteRenderer>().color -= new Color32(0, 0, 0, 5);
        transform.localScale -= new Vector3(0.02f, 0.02f, 0);
        Debug.Log("cancle");

        if (GetComponent<SpriteRenderer>().color.a <= 0 && !isRecycle)
        {
            CancelInvoke();
            recycle(this);
            isRecycle = true;
        }
    }
    public void des2()
    {
        GetComponent<SpriteRenderer>().color -= new Color32(0, 0, 0, 3);
        transform.localScale -= new Vector3(0.017f, 0.017f, 0);
        Debug.Log("cancle");


        if (GetComponent<SpriteRenderer>().color.a <= 0 && !isRecycle)
        {
            CancelInvoke();
            recycle(this);
            isRecycle = true;
        }
    }
}
