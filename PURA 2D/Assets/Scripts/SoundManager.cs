using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{


    public AudioClip second;

    [SerializeField]
    public AudioClip pop;
    [SerializeField]
    private AudioSource source;

    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
