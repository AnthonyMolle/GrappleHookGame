using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioKiller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KillAudio());   
    }

    private IEnumerator KillAudio()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
