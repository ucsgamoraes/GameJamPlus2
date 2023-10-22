using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseText : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    
    [SerializeField]
    private float duration = 1.0f;

    [SerializeField]
    private Vector3 breathIn;

    [SerializeField]
    private Vector3 breathOut;

    private bool isBreathingIn = true;
    private float currentTime = 0.0f;
    void Awake()
    {
        if (!target)
        {
            target = this.gameObject;
        }

    }

    void Update()
    {
        PulseUpdate();        
    }

    private void PulseUpdate() 
    {
        Vector3 currentScale = isBreathingIn ? breathOut : breathIn;
        Vector3 targetScale = isBreathingIn ? breathIn : breathOut;
        float lerpFactor = currentTime / duration;
        
        currentTime += Time.deltaTime;
        target.transform.localScale = Vector3.Lerp(currentScale, targetScale, lerpFactor);

        if (lerpFactor >= 1.0f)
        {
            isBreathingIn = !isBreathingIn;
            currentTime = 0.0f;
        }
    }
}
