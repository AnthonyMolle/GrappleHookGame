using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 3.0f;
    [SerializeField] GameObject point1;
    [SerializeField] GameObject point2;
    [SerializeField] float spawnValue = 1.0f;
    //public bool initialload = true;
    public bool goingRight = true;
    public bool goingLeft = false;

    private bool hooked = false;

    void Start()
    {
        Vector3 distance = new Vector3(Mathf.Abs(point1.transform.position.x - point2.transform.position.x),Mathf.Abs(point1.transform.position.y - point2.transform.position.y),0.0f);
        Debug.Log(distance + "move");
        Vector3 spawnPoint = new Vector3(point2.transform.position.x + distance.x * spawnValue, point2.transform.position.y + distance.y * spawnValue,0.0f);
        point1.transform.SetParent(null, true);
        point2.transform.SetParent(null, true);
        transform.position = spawnPoint;
        
        //transform.position = Vector3.MoveTowards(spawnPoint, point1.transform.position, moveSpeed *Time.deltaTime);
        Debug.Log("spawnpoint" + spawnPoint);
        Debug.Log(point1.transform.position-spawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hooked)
        {
            if(goingRight){
                transform.position = Vector3.MoveTowards(transform.position, point1.transform.position, moveSpeed *Time.deltaTime);
                
            }
            if(goingLeft){
                transform.position = Vector3.MoveTowards(transform.position, point2.transform.position, moveSpeed *Time.deltaTime);
            }
            if(transform.position.x >= point1.transform.position.x-.1){
                Debug.Log("hit right");
                goingLeft = true;
                goingRight = false;
            }
            if(transform.position.x <= point2.transform.position.x+.1){
                Debug.Log("hit left");
                goingRight = true;
                goingLeft = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.GetComponent<Hook>() != null)
        {
            hooked = true;
        }

        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            Die(other.gameObject.GetComponent<PlayerController>());
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.GetComponent<Hook>() != null)
        {
            hooked = false;
        }
    }

    private void Die(PlayerController player)
    {
        player.GrappleRelease();
        Destroy(gameObject);
    }
}
