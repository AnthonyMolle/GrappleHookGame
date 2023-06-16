using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] GameObject musicOnButton;
    [SerializeField] GameObject musicOffButton;

    private void Start() 
    {
        //check to see if the music was previously toggled on or off
    }

    public void MusicToggle()
    {
        if (musicOnButton.activeSelf == true)
        {
            musicOnButton.SetActive(false);
            musicOffButton.SetActive(true);
        }

        else if (musicOffButton.activeSelf == true)
        {
            musicOffButton.SetActive(false);
            musicOnButton.SetActive(true);
        }
    }
}
