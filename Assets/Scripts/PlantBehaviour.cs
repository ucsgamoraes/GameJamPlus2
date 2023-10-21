using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehaviour : MonoBehaviour
{
    Vector3 worldPosition;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 worldPosVec2 = new Vector2(worldPosition.x, worldPosition.y);
        Debug.Log(Vector2.Angle(worldPosVec2, Vector2.up));

    }
}
