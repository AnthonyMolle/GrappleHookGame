using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] Settings settings;
    [SerializeField] AudioSource audio;

    private void Start() 
    {
        if(!settings.settings.musicPlaying)
        {
            audio.volume = 0;
        }
        else
        {
            audio.volume = 0.088f;
        }
    }
}
