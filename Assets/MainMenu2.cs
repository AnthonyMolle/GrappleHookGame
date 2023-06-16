using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class MainMenu2 : MonoBehaviour
{
    private Settings settingsScript;
    [SerializeField] TextMeshProUGUI heightText;
    // Start is called before the first frame update
    void Start()
    {
        settingsScript = GetComponent<Settings>();
        Debug.Log(settingsScript.settings.highScore);
        heightText.text = settingsScript.settings.highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
