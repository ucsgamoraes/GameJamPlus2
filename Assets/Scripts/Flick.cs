using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Flick : MonoBehaviour
{
    public float toggleInterval = 1.0f; // Set the time interval in seconds
    private SpriteRenderer spriteRenderer;
    public float timer;
    public float time;
    public bool aaa;

    private void Start()
    {
        spriteRenderer = GetComponent <SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(aaa && timer > time)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            timer = 0;
        }
    }
    public void StartToggle()
    {
        aaa = true;
    }
    public void StopToggle()
    {
        aaa = false;
    }
}