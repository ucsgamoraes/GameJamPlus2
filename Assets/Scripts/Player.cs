
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Vector3 worldPosition;
    public SpriteRenderer square;

    public GameObject plantPrefab;

    public Vector2 currentAimDir;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 snapedPos = new Vector2(Mathf.FloorToInt(worldPosition.x), Mathf.FloorToInt(worldPosition.y)) + Vector2.one / 2.0f;
        square.transform.position = snapedPos;

        if(Input.GetMouseButtonDown(1))
        {
            PlantManager.Instance.InstantiatePlant(snapedPos);
        }
    }


}
