using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MusicManager : MonoBehaviour
{
    [SerializeField] GameObject musicOnButton;
    [SerializeField] GameObject musicOffButton;
    private Settings settingsScript;

    private void Start() 
    {
        settingsScript = GetComponent<Settings>();
        //check to see if the music was previously toggled on or off
        
        if(settingsScript.settings.musicPlaying){
            if(musicOffButton.activeSelf){
                musicOffButton.SetActive(false);
                musicOnButton.SetActive(true);
            }
            
        }
        else{
 
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
            
            settingsScript.settings.musicPlaying = false;
            string output = JsonUtility.ToJson(settingsScript.settings);
            File.WriteAllText(Application.dataPath + "/Scripts/settings.txt", output);
            musicOnButton.SetActive(false);
            musicOffButton.SetActive(true);
        }

        else if (musicOffButton.activeSelf == true)
        {
            settingsScript.settings.musicPlaying = true;
            string output = JsonUtility.ToJson(settingsScript.settings);
            File.WriteAllText(Application.dataPath + "/Scripts/settings.txt", output);
            musicOffButton.SetActive(false);
            musicOnButton.SetActive(true);
        }
    }
}
