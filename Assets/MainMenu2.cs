using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class MainMenu2 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI heightText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        heightText.text = PlayerPrefs.GetInt("hiscore", 0).ToString("F0");
    }
}
