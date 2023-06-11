using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] LineRenderer grappleLine;
    [SerializeField] GameObject grapplePoint;
    [SerializeField] GameObject indicator;

    [SerializeField] GameObject grapplePrefab;

    [SerializeField] Camera cam;
    [SerializeField] float verticalPlayerSpeed;
    [SerializeField] float grappleSpeed = 1;
    [SerializeField] float reelSpeed = 100;
    [SerializeField] float distanceCutoff = 1;
    [SerializeField] float playerGravity;
    [SerializeField] float grappleDamping = 1;
    [SerializeField] float grappleFrequency = 1000000;

    private bool fireHeld = false;
    private bool firingHook = false;
    private bool grappleReady = true;
    private bool grappling = false;

    private Vector2 mousePosition;
    private Vector2 mouseDirection;
    private Vector2 grappleDirection;

    private GameObject currentGrapplePoint;
    private SpringJoint2D currentSpring;

    private void Start() 
    {
        grappleLine.positionCount = 2;
    }

    private void Update() 
    {
        grappleLine.SetPosition(0, transform.position);
        grappleLine.SetPosition(1, grapplePoint.transform.position);

        grappleDirection = (Vector2)(grapplePoint.transform.position - gameObject.transform.position);

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection = mousePosition - (Vector2)gameObject.transform.position;
        float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
        indicator.transform.eulerAngles = new Vector3(0, 0, angle - 90);

        if (firingHook == false)
        {
             grapplePoint.transform.position = gameObject.transform.position;
             Debug.Log("return");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fireHeld = true;
            firingHook = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            fireHeld = false;
            firingHook = false;
        }
        
        if (fireHeld == false)
        {
            if (grappling)
            {
                grappling = false;
                firingHook = false;
                GrappleRelease();
            }
            fireHeld = false;
            firingHook = false; //temp
            grappleReady = true; //temp
        }

        if (grappling)
        {
            if (currentSpring.distance > distanceCutoff)
            {
                currentSpring.distance -= reelSpeed * Time.deltaTime;
            }
            
        }

    }

    private void FixedUpdate() 
    {
        if (grappleReady && fireHeld)
        {
            grapplePoint.GetComponent<Rigidbody2D>().AddForce(mouseDirection.normalized * grappleSpeed);
            grappleReady = false;
        }
        else if (fireHeld)
        {

        }
        else
        {
            grapplePoint.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        
    }

    public void GrappleHit(Transform hitPoint)
    {
        if (!grappling)
        {
            grappling = true;

            currentSpring = gameObject.AddComponent<SpringJoint2D>();
            currentSpring.dampingRatio = grappleDamping;
            currentSpring.frequency = grappleFrequency;

            currentGrapplePoint = Instantiate(grapplePrefab, hitPoint.position, Quaternion.identity);
            currentSpring.connectedBody = currentGrapplePoint.GetComponent<Rigidbody2D>();

            grapplePoint.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0;
            // rb.AddForce(grappleDirection.normalized * reelSpeed);
        }
    }

    // private void OnCollisionEnter2D(Collision2D other) 
    // {
    //     if (grappling && other.gameObject.layer == LayerMask.NameToLayer("Level"))
    //     {
    //         //rb.velocity = new Vector2(0, 0);
    //         grappling = false;
    //         firingHook = false;
    //         GrappleRelease();
    //     }    
    // }

    public void GrappleRelease()
    {
        rb.gravityScale = playerGravity;

        Destroy(currentSpring);
        Destroy(currentGrapplePoint);
    }
}
