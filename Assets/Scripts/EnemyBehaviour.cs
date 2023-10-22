using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = .01f;
    public float range;
    public LayerMask mask;
    public float timer;
    public float hitInterval;
    public int lifePoints;

    Vector2 GetClosestPlant()
    {
        float minDist = float.MaxValue;
        Vector2 minPlant = Vector2.zero;

        foreach (var plant in PlantManager.Instance.instantiatedPlants)
        {
            float currentDist = Vector2.Distance(transform.position, plant.Key);
            if (currentDist < minDist)
            {
                minDist = currentDist;
                minPlant = plant.Key;
            }
        }
        return minPlant;
    }

    public void TakeDamage (int amount)
    {
        if(lifePoints <= 0 ) { return; }

        lifePoints -= amount;

        if (lifePoints <= 0) { OnDead();  }

    }

    public void OnDead ()
    {
        Destroy(gameObject);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        Vector3 target = GetClosestPlant();
        Vector2 diff = transform.position - target;

        if( diff.sqrMagnitude > range )
        {
            transform.position -= transform.TransformDirection(diff.normalized) * speed;
        }

        Vector3 direction = target - transform.position;
        Debug.DrawLine(transform.position, transform.position + direction* 5);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, range, mask);

        if (hit.collider)
        {
            // You can perform actions here, like attacking the plant.
            Debug.Log("Plant detected!");
        }
    }
}
