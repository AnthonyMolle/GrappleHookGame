using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusicManager : MonoBehaviour
{
    [SerializeField] float volume;
    [SerializeField] AudioSource music;


    void Start()
    {
        if (PlayerPrefs.GetInt("musictoggle", 1) == 0)
        {
            music.volume = 0;
        }
        else
        {
            music.volume = volume;
        }
    }

}
