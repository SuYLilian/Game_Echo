using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    #region old
    

    //public GameObject gameObjectPrefab;
    public float slideSpeed = 500f;
    public float destroyX = -500f;

    //private GameObject content;
    private Vector2 touchStartPosition;
    private Vector2 touchDelta;
    private bool isDragging;
    public ScrollRect scrollRect;

    void Start()
    {
        // Get the child content game object
        //content = transform.GetChild(0).gameObject;

        // Instantiate and add the game objects to the content
        /*for (int i = 0; i < 10; i++)
        {
            GameObject newGameObject = Instantiate(gameObjectPrefab, content.transform);
            newGameObject.transform.localPosition = new Vector3(100f * i, 0f, 0f);
        }*/

        // Get the scroll rect component
        //scrollRect = GetComponent<ScrollRect>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                // If the touch is within the content area, start dragging
                if (RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), touch.position))
                {
                    touchStartPosition = touch.position;
                    isDragging = true;

                    // Disable the scroll rect component while dragging
                    scrollRect.enabled = false;
                }
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (isDragging)
                {
                    touchDelta = touch.position - touchStartPosition;
                    touchStartPosition = touch.position;

                    // Slide the game objects left or right
                    transform.Translate(-slideSpeed * Time.deltaTime * Vector2.left * touchDelta.x);
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;

                // Re-enable the scroll rect component
                scrollRect.enabled = true;
            }
        }

        // Destroy any game objects that have moved too far left
       
            if (transform.localPosition.x < destroyX)
            {
                Destroy(gameObject);
            }
        

        // Add new game objects as needed
      
    }

    #endregion
}
