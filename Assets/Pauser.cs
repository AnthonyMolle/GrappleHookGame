using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    public void Pause(float timescale, float duration)
    {
        StartCoroutine(PauseForSeconds(timescale, duration));
    }

    private IEnumerator PauseForSeconds(float timescale, float duration)
    {
        Time.timeScale = timescale;
        yield return new WaitForSeconds(duration);
        Time.timeScale = 1;
    }
}
