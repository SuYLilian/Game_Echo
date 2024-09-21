using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class DragMessage : MonoBehaviour,IBeginDragHandler,IDragHandler/*,IEndDragHandler*///33333,IPointerDownHandler
{
    Vector2 lastTouchPosition;
    float x, y, z;
    public bool blockX, blockY, blockZ;
    Vector3 orignalPosition;
    bool canDrag = true, canMove = true;
    float disappearSpeed = 2000f;
    RectTransform rectTransform;
    //public GameObject greenMark, redMark;
    //public GameObject _greenMark, _redMark;
    bool isInstantiate_redMark = false, isInstantiate_greenMark = false;
    //[SerializeField] Animator greenLight_ani, redLight_ani;

    bool canDestroy = false;
    GameObject commentGroup;

    ScrollRect MainScroll;

    public bool Dragging;

    Vector2 startingMousePos;
    bool isDragging = false;
    bool haveTouched = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        //orignalPosition = new Vector3(489.9842f, rectTransform.position.y, rectTransform.position.z);
        commentGroup = gameObject.transform.parent.gameObject;
        Debug.Log(rectTransform.localPosition);
        //333333MainScroll = transform.parent.parent.GetComponent<ScrollRect>();
        //Debug.Log("ori:"+orignalPosition);
    }
    void Update()
    {

       /* 33333if (Dragging)
        {
             MainScroll.enabled = !(Dragging && Mathf.Abs(Input.mousePosition.x - startingMousePos.x) > 75);
            transform.localPosition = new Vector2(Input.mousePosition.x - startingMousePos.x, transform.localPosition.y);

            if (Input.touchCount == 0)
            {
                Dragging = false; 
                OnEndDrag();
            }
        }
        else
        {
            transform.localPosition = new Vector2(0, transform.localPosition.y);
        }33333*/
        /*transform.localPosition = new Vector2(
           Dragging ?
           (Input.mousePosition.x - startingMousePos.x) :
           0, transform.localPosition.y);*/

        /*if(haveTouched && Input.touchCount!=1)
        {
            if ((rectTransform.localPosition.x > 148 || rectTransform.localPosition.x < -148) && canDrag && canDestroy)
            {
                canDrag = false;
            }
            else if (rectTransform.localPosition.x <= 148 && rectTransform.localPosition.x >= -148)
            {
                if (isInstantiate_redMark)
                {
                    redLight_ani.SetBool("isShow", false);
                }
                if (isInstantiate_greenMark)
                {
                    greenLight_ani.SetBool("isShow", false);
                }
                rectTransform.localPosition = orignalPosition;
                haveTouched = false;
                //canDrag = true;
            }
        }*/
        //3333return;

        if(isDragging && Input.touchCount==0)
        {
            isDragging = false;
            Debug.Log("end" + transform.localPosition);

            if ((rectTransform.localPosition.x > 148 || rectTransform.localPosition.x < -148) && canDrag && canDestroy)
            {
                canDrag = false;
            }
            else if (rectTransform.localPosition.x <= 148 && rectTransform.localPosition.x >= -148)
            {
                if (isInstantiate_redMark)
                {
                    //redLight_ani.SetBool("isShow", false);
                }
                if (isInstantiate_greenMark)
                {
                   // greenLight_ani.SetBool("isShow", false);
                }
                rectTransform.localPosition = orignalPosition;
                haveTouched = false;
                canDrag = true;
            }
            /*else
            {
                if (isInstantiate_redMark)
                {
                    redLight_ani.SetBool("isShow", false);
                }
                if (isInstantiate_greenMark)
                {
                    greenLight_ani.SetBool("isShow", false);
                }
                rectTransform.localPosition = orignalPosition;
                haveTouched = false;
                canDrag = true;
            }*/
        }

        #region Drag
        if (!canDrag && canMove)
        {
            if (rectTransform.localPosition.x < -148)
            {
                // canDrag = false;
                rectTransform.localPosition -= new Vector3(disappearSpeed * Time.deltaTime, 0, 0);
                //Debug.Log(rectTransform.localPosition);

                if (!isInstantiate_redMark)
                {
                    //Vector3 worldPoint = Camera.main.ScreenToWorldPoint(transform.position);
                    //_redMark = Instantiate(redMark, new Vector3(-1.7f, transform.position.y, 0), Quaternion.identity);
                    //redLight_ani = _redMark.GetComponent<Animator>();
                    //_redMark.SetActive(true);
                    //isInstantiate_redMark = true;
                }
                else if (isInstantiate_redMark)
                {
                    //redLight_ani.SetBool("isShow", true);
                }

                if (rectTransform.localPosition.x <= -850)
                {
                    //FindObjectOfType<CommentManager>().commentCollection.Add(transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
                    //FindObjectOfType<CommentManager>().collectionNum_all++;
                    canMove = false;
                    commentGroup.GetComponent<RectTransform>().sizeDelta -= new Vector2(0, 312.4f);
                   // Destroy(_redMark);
                    //Destroy(_greenMark);
                    Destroy(gameObject);
                    // StartCoroutine(DestroyMsg()); 
                }
            }
            else if (rectTransform.localPosition.x > 148)
            {
                //canDrag = false;
                rectTransform.localPosition += new Vector3(disappearSpeed * Time.deltaTime, 0, 0);
                if (!isInstantiate_greenMark)
                {
                    //Vector3 worldPoint = Camera.main.ScreenToWorldPoint(transform.position);
                   // _greenMark = Instantiate(greenMark, new Vector3(1.7f, transform.position.y, 0), Quaternion.identity);
                    //greenLight_ani = _greenMark.GetComponent<Animator>();
                    //_greenMark.SetActive(true);
                    isInstantiate_greenMark = true;
                }
                else if (isInstantiate_greenMark)
                {
                    //greenLight_ani.SetBool("isShow", true);
                }

                if (rectTransform.localPosition.x > 850)
                {
                    FindObjectOfType<CommentManager>().commentCollection.Add(transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
                    FindObjectOfType<CommentManager>().collectionNum_all++;
                    if (gameObject.tag == "Correct")
                    {
                        FindObjectOfType<CommentManager>().collectionNum_correct++;
                    }
                    canMove = false;
                    commentGroup.GetComponent<RectTransform>().sizeDelta -= new Vector2(0, 312.4f);
                   // Destroy(_greenMark);
                    //Destroy(_redMark);
                    Destroy(gameObject);
                    //StartCoroutine(DestroyMsg());

                }
            }

        }
        #endregion




    }
    void OnEndDrag()
    {
        //MainScroll.enabled = true;
        float xdelta = Input.mousePosition.x - startingMousePos.x;
        if (xdelta > 30) { Debug.Log("©¹¤S©Ô"); }
        if (xdelta < -30) { Debug.Log("©¹¥ª©Ô"); }
        Debug.Log(xdelta);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        lastTouchPosition = eventData.position;
        lastTouchPosition = Camera.main.ScreenToWorldPoint(lastTouchPosition);
        orignalPosition = rectTransform.localPosition;
        haveTouched = true;
        isDragging = true;

    }

    public void OnDrag(PointerEventData eventData)
    {

        if (canDrag)
        {
            //Debug.Log(rectTransform + "," + orignalPosition + "," + lastTouchPosition);
            //rectTransform = GetComponent<RectTransform>();
            Vector2 currentTouchPosition = eventData.position;
            currentTouchPosition = Camera.main.ScreenToWorldPoint(currentTouchPosition);
            Vector2 diff = currentTouchPosition - lastTouchPosition;
            x = y = z = 0;

            if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
            {
                if (!blockX)
                {
                    x = diff.x;
                }
                if (!blockY)
                {
                    y = diff.y;
                }
                if (!blockZ)
                {
                    z = transform.localPosition.z;
                }

                transform.position = transform.position + new Vector3(x, y, z);
                lastTouchPosition = currentTouchPosition;
                canDestroy = true;
                if(!isDragging)
                {
                    isDragging = true;
                }
            }
            else
            {
                canDestroy = false;
                // Debug.Log("Can not drag");
            }

        }

        //Debug.Log(rectTransform.position);

        if (rectTransform.localPosition.x > 148)
        {
            if (!isInstantiate_greenMark)
            {
                //Vector3 worldPoint = Camera.main.ScreenToWorldPoint(transform.position);
                //Debug.Log(worldPoint);
               // _greenMark = Instantiate(greenMark, new Vector3(1.7f, transform.position.y, 0), Quaternion.identity);
                //greenLight_ani = _greenMark.GetComponent<Animator>();
               // _greenMark.SetActive(true);
                //isInstantiate_greenMark = true;
            }
            else if (isInstantiate_greenMark)
            {
               // greenLight_ani.SetBool("isShow", true);
                //redLight_ani.SetBool("isShow", false);
            }
        }

        if (rectTransform.localPosition.x < -148)
        {
            if (!isInstantiate_redMark)
            {
                //Vector3 worldPoint = Camera.main.ScreenToWorldPoint(transform.position);
                //Debug.Log(worldPoint);
                //_redMark = Instantiate(redMark, new Vector3(-1.7f, transform.position.y, 0), Quaternion.identity);
                //redLight_ani = _redMark.GetComponent<Animator>();
                //_redMark.SetActive(true);
                //isInstantiate_redMark = true;
            }
            else if (isInstantiate_redMark)
            {
                //redLight_ani.SetBool("isShow", true);
                //greenLight_ani.SetBool("isShow", false);

            }
        }

        if (rectTransform.localPosition.x <= 148 && rectTransform.localPosition.x >= -148)
        {
            if (isInstantiate_redMark)
            {
                //redLight_ani.SetBool("isShow", false);
            }
            if (isInstantiate_greenMark)
            {
               // greenLight_ani.SetBool("isShow", false);
            }
        }

        /*if ((rectTransform.position.x - orignalPosition.x > 0|| rectTransform.position.x - orignalPosition.x < 0) && canDrag)
        {
            canDrag = false;
        }*/

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        //Debug.Log("end : " + rectTransform.localPosition);
        

        if ((rectTransform.localPosition.x > 148 || rectTransform.localPosition.x < -148) && canDrag && canDestroy)
        {
            canDrag = false;
            
        }
        else if (rectTransform.localPosition.x <= 148 && rectTransform.localPosition.x >= -148)
        {
            if (isInstantiate_redMark)
            {
                //redLight_ani.SetBool("isShow", false);
            }
            if (isInstantiate_greenMark)
            {
                //greenLight_ani.SetBool("isShow", false);
            }
            rectTransform.localPosition = orignalPosition;
            haveTouched = false;
            canDrag = true;
            
        }
        else
        {
            if (isInstantiate_redMark)
            {
                //redLight_ani.SetBool("isShow", false);
            }
            if (isInstantiate_greenMark)
            {
                //greenLight_ani.SetBool("isShow", false);
            }
            rectTransform.localPosition = orignalPosition;
            haveTouched = false;
            canDrag = true;
        }
        //throw new System.NotImplementedException();

    }



    IEnumerator DestroyMsg()
    {
        yield return new WaitForSeconds(0.8f);
        commentGroup.GetComponent<RectTransform>().sizeDelta -= new Vector2(0, 327.4f);
        Destroy(gameObject);
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        Dragging = true;
        startingMousePos = Input.mousePosition;
    }


}
