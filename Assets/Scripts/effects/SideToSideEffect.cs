using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSideEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float duration = 1.0f;

    [SerializeField]
    private Vector3 initialPosition;

    [SerializeField]
    private Vector3 finalPosition;

    private bool moving = true;
    private float currentTime = 0.0f;

    void Update()
    {
        PulseUpdate();
    }

    private void PulseUpdate()
    {
        Vector3 currentScale = moving ? finalPosition : initialPosition;
        Vector3 targetScale = moving ? initialPosition : finalPosition;
        float lerpFactor = currentTime / duration;

        currentTime += Time.deltaTime;
        target.transform.localPosition = Vector3.Lerp(currentScale, targetScale, lerpFactor);

        if (lerpFactor >= 1.0f)
        {
            moving = !moving;
            currentTime = 0.0f;
        }
    }
}
