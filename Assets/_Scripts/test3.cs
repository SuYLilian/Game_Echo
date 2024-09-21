using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class test3 : MonoBehaviour, IDragHandler, IEndDragHandler
{
   // public GameObject gameObjectPrefab;
    public float slideSpeed = 50f;
    public float destroyThreshold = -50f;
    public float spawnThreshold = 500f;

    public ScrollRect scrollRect;
    private bool isDragging = false;

    public void Start()
    {
        //scrollRect = GetComponent<ScrollRect>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Check if touch is over a UI element
        if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            // Move the game objects
            
                //transform.position += Vector3.right * Input.GetTouch(0).deltaPosition.x * slideSpeed;
            transform.Translate(slideSpeed * Time.deltaTime * Vector2.left);

            isDragging = true;
        }
        else
        {
            scrollRect.OnDrag(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        // Enable the scroll rect component
        scrollRect.enabled = true;
    }

   /* public void SpawnGameObject(float xPosition)
    {
        // Instantiate a new game object and add it as a child of this object
        GameObject newGameObject = Instantiate(gameObjectPrefab, transform);
        newGameObject.transform.localPosition = new Vector3(xPosition, 0, 0);
    }*/

    public void Update()
    {
        if (!isDragging)
        {
            // Destroy game objects that have moved too far left
          
                if (transform.localPosition.x < destroyThreshold)
                {
                    Destroy(gameObject);
                }
            

            // Add new game objects as needed
           /* float rightmostX = 0f;
            foreach (Transform child in transform)
            {
                if (child.localPosition.x > rightmostX)
                {
                    rightmostX = child.localPosition.x;
                }
            }
            if (rightmostX < spawnThreshold)
            {
                SpawnGameObject(rightmostX + gameObjectPrefab.GetComponent<RectTransform>().rect.width);
            }*/
        }
    }
}
