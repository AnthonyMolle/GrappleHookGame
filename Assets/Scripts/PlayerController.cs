using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] LineRenderer grappleLine;
    [SerializeField] GameObject grapplePoint;
    [SerializeField] GameObject indicator;

    [SerializeField] Camera cam;
    

    [SerializeField] float verticalPlayerSpeed;

    private bool leftHeld = false;
    private bool rightHeld = false;
    private bool fireHeld = false;
    private bool firingHook = true;

    private Vector2 mousePosition;

    private void Start() 
    {
        grappleLine.positionCount = 2;
    }

    private void Update() 
    {
        grappleLine.SetPosition(0, transform.position);
        grappleLine.SetPosition(1, grapplePoint.transform.position);

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 launcherDirection = mousePosition - (Vector2)gameObject.transform.position;
        float angle = Mathf.Atan2(launcherDirection.y, launcherDirection.x) * Mathf.Rad2Deg;
        indicator.transform.eulerAngles = new Vector3(0, 0, angle - 90);

        if (firingHook == false)
        {
             grapplePoint.transform.position = gameObject.transform.position;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            fireHeld = true;
        }
        else
        {
            fireHeld = false;
        }

        //handling input for left movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            leftHeld = true;
        }
        else
        {
            leftHeld = false;
        }

        //handling input for left movement
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rightHeld = true;
        }
        else
        {
            rightHeld = false;
        }
    }

    private void FixedUpdate() 
    {
        
    }
}
