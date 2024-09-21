using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] bgmClips;
    public AudioClip[] seClips;

    public AudioSource audioSource;
    public static AudioManager instance = null;



    public void PlayClip_BGM(AudioClip _clip)
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
