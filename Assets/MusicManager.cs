using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MusicManager : MonoBehaviour
{
    [SerializeField] GameObject musicOnButton;
    [SerializeField] GameObject musicOffButton;

    [SerializeField] AudioSource music;
    [SerializeField] float musicVolume;

    private void Update() 
    {
        
        if(PlayerPrefs.GetInt("musictoggle", 1) == 1){
            music.volume = musicVolume;
            if(musicOffButton.activeSelf){
                
                musicOffButton.SetActive(false);
                musicOnButton.SetActive(true);
            }
            
        }
        else if (PlayerPrefs.GetInt("musictoggle", 1) == 0){
 
           music.volume = 0;
           musicOffButton.SetActive(true);
           if(musicOnButton.activeSelf){
                musicOffButton.SetActive(true);
                musicOnButton.SetActive(false);
            }
            
        }
        

    }

    public void MusicToggle()
    {
        if (musicOnButton.activeSelf == true)
        {
            
            PlayerPrefs.SetInt("musictoggle", 0);
            musicOnButton.SetActive(false);
            musicOffButton.SetActive(true);
        }

        else if (musicOffButton.activeSelf == true)
        {
            PlayerPrefs.SetInt("musictoggle", 1);
            musicOffButton.SetActive(false);
            musicOnButton.SetActive(true);
        }
    }
}
