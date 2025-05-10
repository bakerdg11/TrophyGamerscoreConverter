using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;
    public AudioClip beginClickSound;
    public AudioClip calculateClickSound;
    public AudioClip resetClickSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void PlayBeginSound()
    {
        if (beginClickSound != null)
        {
            audioSource.PlayOneShot(beginClickSound);
        }
    }

    public void PlayCalculateSound()
    {
        if (calculateClickSound != null)
        {
            audioSource.PlayOneShot(calculateClickSound);
        }
    }

    public void PlayResetSound()
    {
        if (resetClickSound != null)
        {
            audioSource.PlayOneShot(resetClickSound);
        }
    }


}
