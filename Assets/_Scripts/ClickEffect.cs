using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class ClickEffect : MonoBehaviour
{
    public GameObject touchParticle;
    Vector3 touchPos_pool;

    ObjectPool<ClickAniFunc> particlePool;

    private void Start()
    {
       /* particlePool = new ObjectPool<ClickAniFunc>(
       () =>
       {
           ClickAniFunc b = Instantiate(touchParticle, gameObject.transform).GetComponent<ClickAniFunc>();
           b.recycle = (bullet) =>
           {
               particlePool.Release(bullet);
           };
           return b;
       },
       (clickAniFunc) =>
       {
           clickAniFunc.transform.position = touchPos_pool;           
           clickAniFunc.gameObject.SetActive(true);
       },
       (clickAniFunc) =>
       {
           clickAniFunc.gameObject.SetActive(false);
       },
       (clickAniFunc) =>
       {
           Destroy(clickAniFunc.gameObject);
       }, true, 3, 10
       );*/
    }
    void Update()
    {
        /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPosition = Input.GetTouch(0).position;
            touchPosition.z = -9; // Set the z position to 10 units away from the camera
            touchPos_pool = touchPosition;
            ClickAniFunc b = particlePool.Get();
        }*/
    }
}
