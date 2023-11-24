using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioHandler : MonoBehaviour
{
    public void PlayThisAudio()
    {
        gameObject.GetComponent<AudioSource>().Play();

    }
}
