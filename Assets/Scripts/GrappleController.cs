using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleController : MonoBehaviour
{
    [SerializeField] Transform grappleHook;
    [SerializeField] Transform grappleOrigin;
    [SerializeField] LineRenderer grappleLine;

    // Start is called before the first frame update
    void Start()
    {
        grappleLine.positionCount = 2;
    }

    private void Update() 
    {
        grappleLine.SetPosition(0, grappleOrigin.transform.position);
        grappleLine.SetPosition(1, grappleHook.transform.position);    
    }

}
