using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logo : MonoBehaviour
{
    [SerializeField] private CanvasGroup logoImage;
    public bool done = false;
    private bool fadeOut = false;
    // Start is called before the first frame update
    void Start()
    {
        logoImage.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!fadeOut){
            logoImage.alpha += Time.deltaTime;
            if(logoImage.alpha >= 1){
                fadeOut = true;
            }
        }
        else if(fadeOut && !done){
            logoImage.alpha -= Time.deltaTime;
            if(logoImage.alpha <= 0){
                done = true;
            }
            
        }
        if(done){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

    }
}
