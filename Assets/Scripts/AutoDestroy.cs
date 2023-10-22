using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float time;
    public bool destroyOnTime;

    private void Start()
    {
        if(destroyOnTime)
        Destroy(gameObject, time);
    }

    void DestroyObject () { Destroy(gameObject); }
}
