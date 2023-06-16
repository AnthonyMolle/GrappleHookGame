using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoEffect : MonoBehaviour
{
    [SerializeField] public Rigidbody2D player;
    [SerializeField] public ParticleSystem dust;
    // Update is called once per frame
    void Update()
    {
        if(player.velocity.y > 0){
            dust.Play();
        }
    }
}
