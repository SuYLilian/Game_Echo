using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class test2 : MonoBehaviour, IDragHandler, IEndDragHandler
{
    //public GameObject gameObjectPrefab;
    public float slideSpeed = 100f;
    public float destroyThreshold = -500f;
    public float spawnThreshold = 500f;

    public ScrollRect scrollRect;

    public void Start()
    {
       // scrollRect = GetComponent<ScrollRect>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            // Move the game objects
            
                transform.position += Vector3.right * eventData.delta.x * slideSpeed;
            
        }
        else
        {
            scrollRect.OnDrag(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
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
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            // Destroy game objects that have moved too far left
          
                if (transform.localPosition.x < destroyThreshold)
                {
                    Destroy(gameObject);
                }
            

            // Add new game objects as needed
           /* float rightmostX = 0f;
           
                if (transform.localPosition.x > rightmostX)
                {
                    rightmostX = child.localPosition.x;
                }
            
            if (rightmostX < spawnThreshold)
            {
                SpawnGameObject(rightmostX + gameObjectPrefab.GetComponent<RectTransform>().rect.width);
            }*/
        }
    }
}
