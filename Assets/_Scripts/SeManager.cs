using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeManager : MonoBehaviour
{
    public AudioClip[] seClips;

    public AudioSource audioSource;
    public static SeManager instance = null;



    public void PlayClip_SE(AudioClip _clip)
    {
        audioSource.PlayOneShot(_clip);
    }

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
