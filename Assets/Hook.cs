using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] PlayerController player;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Level"))
        {
            player.GrappleHit(gameObject.transform);
        }    
    }
}
