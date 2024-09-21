using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLight : MonoBehaviour
{
    bool showLight = true;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(showLight)
        {
            spriteRenderer.color += new Color(0, 0, 0, 5f * Time.deltaTime);
            if(spriteRenderer.color.a>=1)
            {
                showLight = false;
            }
           
        }

        else if(!showLight)
        {
            spriteRenderer.color -= new Color(0, 0, 0, 5f * Time.deltaTime);
            if(spriteRenderer.color.a<=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
