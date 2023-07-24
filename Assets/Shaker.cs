using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shaker : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;
    private float shakeTime = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
            if (shakeTime <= 0)
            {
                CinemachineBasicMultiChannelPerlin perlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                perlin.m_AmplitudeGain = 0;
                shakeTime = 0;
            }
        }
    }

    public void Shake(float duration, float magnitude)
    {
        CinemachineBasicMultiChannelPerlin perlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = magnitude;
        shakeTime = duration;
    }
}
