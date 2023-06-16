using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class GameOver : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI heightText;
    [SerializeField] GameObject player;
    private Settings settingsScript;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        settingsScript = GetComponent<Settings>();
        Debug.Log(heightText.text);
    }
}
