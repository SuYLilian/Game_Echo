using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class ClickAniFunc : MonoBehaviour
{
    public GameObject Triangle1, Triangle2;
    int triNum;
    Vector3 touchPos_pool;

    public static ClickAniFunc instance = null;


    ObjectPool<TriDes> Triangle1_pool;
    ObjectPool<TriDes> Triangle2_pool;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
       
            // MenuManager.canClickBrowserApp = true;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        Triangle1_pool = new ObjectPool<TriDes>(
      () =>
      {
          TriDes one = Instantiate(Triangle1, gameObject.transform).GetComponent<TriDes>();
          one.recycle = (triDes) =>
          {
              Triangle1_pool.Release(triDes);
          };
          return one;
      },
      (triDes) =>
      {
          //triDes.GetComponent<SpriteRenderer>().color = new Color32(1, 1, 1, 1);
          //triDes.transform.localScale = new Vector3(1, 1, 1);
          Debug.Log("get1");
          triDes.transform.position = touchPos_pool;
          float angle = Random.Range(-180, 180);
          triDes.gameObject.SetActive(true);
          triDes.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
          triDes.GetComponent<TriDes>().isRecycle = false;
          triDes.GetComponent<TriDes>().AllDes();
      },
      (triDes) =>
      {
          triDes.gameObject.SetActive(false);
          //triDes.GetComponent<SpriteRenderer>().color = new Color32(1, 1, 1, 1);
          //triDes.transform.localScale = new Vector3(1, 1, 1);
      },
      (triDes) =>
      {
          Destroy(triDes.gameObject);
      }, true, 10,100
      );

        Triangle2_pool = new ObjectPool<TriDes>(
     () =>
     {
         TriDes b = Instantiate(Triangle2, gameObject.transform).GetComponent<TriDes>();
         b.recycle = (triDes) =>
         {
             Triangle2_pool.Release(triDes);
         };
         return b;
     },
     (triDes) =>
     {
         //triDes.GetComponent<SpriteRenderer>().color = new Color32(1, 1, 1, 1);
         //triDes.transform.localScale = new Vector3(1, 1, 1);
         Debug.Log("get2");
         triDes.transform.position = touchPos_pool;
         triDes.gameObject.SetActive(true);
         triDes.GetComponent<TriDes>().isRecycle = false;
         triDes.GetComponent<TriDes>().AllDes();
     },
     (triDes) =>
     {
         triDes.gameObject.SetActive(false);
         //triDes.GetComponent<SpriteRenderer>().color = new Color32(1, 1, 1, 1);
         //triDes.transform.localScale = new Vector3(1, 1, 1);
     },
     (triDes) =>
     {
         Destroy(triDes.gameObject);
     }, true, 10, 100
     );

    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPosition = Input.GetTouch(0).position;
            //touchPosition.z = -9;  Set the z position to 10 units away from the camera
            touchPos_pool = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            touchPos_pool.z = -9;
            //Debug.Log(touchPos_pool);
            //Instantiate(Triangle2, touchPos_pool, Quaternion.identity);

            TriDes two = Triangle2_pool.Get();
            Debug.Log("tri_2");
            triNum = Random.Range(7, 13);

            for (int i = 0; i < triNum; i++)
            {
                Debug.Log("tri_1");
                //GameObject tri = Instantiate(Triangle1, transform.position, Quaternion.identity);
                TriDes one = Triangle1_pool.Get();

            }
        }
    }

}
