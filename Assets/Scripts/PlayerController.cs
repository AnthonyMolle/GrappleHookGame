using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AudioSource reelSFX;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Collider2D playerCollider;

    [SerializeField] LineRenderer grappleLine;
    [SerializeField] GameObject grapplePoint;
    [SerializeField] GameObject indicator;
    

    [SerializeField] GameObject cameraConfiner;
    [SerializeField] TextMeshProUGUI heightText;

    [SerializeField] GameObject grapplePrefab;

    [SerializeField] PhysicsMaterial2D grapplingMaterial;
    [SerializeField] PhysicsMaterial2D releasedMaterial;

    [SerializeField] Camera cam;
    [SerializeField] float grappleRange = 100;
    [SerializeField] float grappleReturnSpeed = 8;
    [SerializeField] float returnEpsilon = 1;
    [SerializeField] float grappleSpeed = 1;
    [SerializeField] float reelSpeed = 100;
    [SerializeField] float reelSpeedGrowth = 0.1f;
    [SerializeField] float maxReelSpeed;
    private float currentReelSpeed;
    [SerializeField] float distanceCutoff = 1;
    [SerializeField] float playerGravity;
    [SerializeField] float grappleDamping = 1;
    [SerializeField] float grappleFrequency = 1000000;
    [SerializeField] float grappleDistance;

    private float currentY;
    private float greatestY;
    private float heightCounter;

    private bool fireHeld = false;
    private bool firingHook = false;
    private bool grappleReady = true;
    private bool grappling = false;
    private bool returning = false;

    private Vector2 mousePosition;
    private Vector2 mouseDirection;
    private Vector2 grappleDirection;

    private GameObject currentGrapplePoint;
    private SpringJoint2D currentSpring;

    private void Start() 
    {
        grappleLine.positionCount = 2;

        greatestY = gameObject.transform.position.y;
        currentY = greatestY;
        heightCounter = 0;
    }

    private void Update() 
    {
        currentY = gameObject.transform.position.y;

        if (currentY > greatestY)
        {
            cameraConfiner.transform.position = new Vector2(cameraConfiner.transform.position.x, cameraConfiner.transform.position.y + (currentY - greatestY));
            heightCounter += currentY - greatestY;
            greatestY = currentY;
        }

        heightText.text = heightCounter.ToString("F3") + "m";

        grappleLine.SetPosition(0, transform.position);
        grappleLine.SetPosition(1, grapplePoint.transform.position);

        grappleDirection = (Vector2)(grapplePoint.transform.position - gameObject.transform.position);

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection = mousePosition - (Vector2)gameObject.transform.position;
        float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
        indicator.transform.eulerAngles = new Vector3(0, 0, angle - 90);

        if (firingHook == false)
        {
            if (returning)
            {
                if((gameObject.transform.position - grapplePoint.transform.position).magnitude < returnEpsilon)
                {
                    returning = false;
                }
                else
                {
                    grapplePoint.transform.position = Vector3.MoveTowards(grapplePoint.transform.position, gameObject.transform.position, grappleReturnSpeed);
                }
            }
            else
            {
                grapplePoint.transform.position = gameObject.transform.position;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fireHeld = true;
            firingHook = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            GrappleRelease();
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
            if (rb.sharedMaterial != grapplingMaterial || playerCollider.sharedMaterial != grapplingMaterial)
            {
                rb.sharedMaterial = grapplingMaterial;
                playerCollider.sharedMaterial = grapplingMaterial;
            }

            if (currentSpring.distance > distanceCutoff)
            {
                if (currentReelSpeed < maxReelSpeed)
                {
                    currentReelSpeed += reelSpeedGrowth;
                }
                currentSpring.distance -= currentReelSpeed * Time.deltaTime;
            }
            
        }
        else
        {
            currentReelSpeed = reelSpeed;
            if (rb.sharedMaterial != releasedMaterial || playerCollider.sharedMaterial != releasedMaterial)
            {
                rb.sharedMaterial = releasedMaterial;
                playerCollider.sharedMaterial = releasedMaterial;
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
            //currentSpring.distance = grappleDistance;

            grapplePoint.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0;
            reelSFX.Play();
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
        firingHook = false;
        returning = true;

        if (currentSpring != null)
        {
            Destroy(currentSpring);
            Destroy(currentGrapplePoint);
            reelSFX.Stop();
        }
    }
}
