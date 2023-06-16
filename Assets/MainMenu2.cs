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
        
    }

    // Update is called once per frame
    void Update()
    {
        settingsScript = GetComponent<Settings>();
        heightText.text = settingsScript.settings.highScore.ToString();
        Debug.Log(heightText.text);
    }
}
