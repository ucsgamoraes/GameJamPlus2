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
    public Transform house;

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

    private void Start()
    {
        house = GameObject.FindGameObjectWithTag("House").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        Vector3 target = GetClosestPlant();
        Vector2 diff = transform.position - target;
        Vector2 diffHouse = transform.position - house.position;
        Debug.Log(target);
        if(diffHouse.sqrMagnitude < diff.sqrMagnitude || PlantManager.Instance.instantiatedPlants.Count == 0)
        {
            target = house.position;
            diff = diffHouse;
        }

        transform.position -= transform.TransformDirection(diff.normalized) * speed * Time.deltaTime;

        Vector3 direction = target - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, range, mask);

        if (hit.collider)
        {
            if (hit.collider.CompareTag("Plant"))
            {
                AttackPlant();
            }
        }
    }

    void AttackPlant()
    {
        Debug.Log("Attack Plant");
    }
}
