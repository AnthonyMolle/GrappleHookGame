using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] GameObject spikes;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = spikes.transform.position;
    }
}
