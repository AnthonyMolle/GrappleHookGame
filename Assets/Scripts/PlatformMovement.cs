using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{



    private bool isMoving = false;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float speedGrowth = .5f;
    [SerializeField] float speedInterval = 2.0f;
    [SerializeField] float maxSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
        StartCoroutine(MyCoroutine());
        Debug.Log("starting coroutine");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isMoving){
           transform.Translate(Vector3.up * speed * Time.deltaTime);
           
        }
    }
    IEnumerator MyCoroutine(){
        
            
        Debug.Log("coroutine running");    
        while(isMoving&&speed<maxSpeed){    
            yield return new WaitForSeconds(speedInterval);
            Debug.Log("changing speed" + speed);
            speed += speedGrowth;
        }   
        
    }
    void startMoving(){
        isMoving = true;
    }
    void stopMoving(){
        isMoving = false;
    }
}
