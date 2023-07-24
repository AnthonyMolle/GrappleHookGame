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
    public bool paused = false;

    [SerializeField] GameObject particlePrefab;
    [SerializeField] GameObject particleScorePrefab;
    [SerializeField] GameObject audioPrefab;

    void Start()
    {
        Vector3 distance = new Vector3(Mathf.Abs(point1.transform.position.x - point2.transform.position.x),Mathf.Abs(point1.transform.position.y - point2.transform.position.y),0.0f);
        Vector3 spawnPoint = new Vector3(point2.transform.position.x + distance.x * spawnValue, point2.transform.position.y + distance.y * spawnValue,0.0f);
        point1.transform.SetParent(null, true);
        point2.transform.SetParent(null, true);
        transform.position = spawnPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hooked && !paused)
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
        //FindObjectOfType<Pauser>().Pause(0.01f, 0.001f);
        FindObjectOfType<Shaker>().Shake(0.2f, 3f);
        Instantiate(particlePrefab, gameObject.transform.position, gameObject.transform.rotation);
        Instantiate(particleScorePrefab, gameObject.transform.position, gameObject.transform.rotation);
        Instantiate(audioPrefab, gameObject.transform.position, gameObject.transform.rotation);

        player.heightCounter += 10;

        
        //player.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(player.gameObject.GetComponent<Rigidbody2D>().velocity.x / player.xDivide, player.boost);

        if (hooked)
        {
            player.GrappleRelease();
        }
        Destroy(gameObject);
    }
}
