using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUiGroup;
    [SerializeField] private GameObject MyCanvas;
    [SerializeField] public CanvasGroup otherUiGroup;
    [SerializeField] public GameObject otherCanvas;
    
    private bool fade = false;
    private bool fadeOut = false;

    public void DoFade(){
        myUiGroup.interactable = false;
        otherUiGroup.interactable = true;
        otherCanvas.SetActive(true);
        fade = true;
    }

    private void Update(){
        if(fade){
            myUiGroup.alpha -= Time.deltaTime;
            if(myUiGroup.alpha <= 0){
                fade = false;
                fadeOut = true;
            }
        }
        if(fadeOut){
            otherUiGroup.alpha += Time.deltaTime;
            if(otherUiGroup.alpha >= 1){
                fadeOut = false;
                MyCanvas.SetActive(false);
            }
        }
    }
}
