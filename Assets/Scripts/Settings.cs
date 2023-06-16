using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Settings : MonoBehaviour
{
    // Start is called before the first frame update

    public TextAsset settingsText;
    
  
    public class SettingsInfo{
        public bool musicPlaying = true;
        public int highScore = 0;
    }

    public SettingsInfo settings = new SettingsInfo();
    void Start()
    {
        string settingsjson = File.ReadAllText(Application.dataPath + "/Scripts/settings.txt");
        settings = JsonUtility.FromJson<SettingsInfo>(settingsjson);
        Debug.Log("value in settigngs " + settings.musicPlaying);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
