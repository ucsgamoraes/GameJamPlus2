using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = .01f;
    public float range;
    public LayerMask mask;
    public float hitInterval;
    public int lifePoints;
    public float attackTimer;
    public float attackCooldown;
    public Transform house;
    public Transform sprite;
    public float offset2;
    public int hitDamage;
    public GameObject explosion;

    Transform GetClosestPlant()
    {
        float minDist = float.MaxValue;
        Transform minPlant = null;

        foreach (var plant in PlantManager.Instance.instantiatedPlants)
        {
            if(plant.Value == null) continue;
            float currentDist = Vector2.Distance(transform.position, plant.Key);
            if (currentDist < minDist)
            {
                minDist = currentDist;
                minPlant = plant.Value.transform;
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
        PlantManager.Instance.instantiatedPlants.Remove(transform.position);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Start()
    {
        house = GameObject.FindGameObjectWithTag("House").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        attackTimer += Time.deltaTime;
        Transform target = GetClosestPlant();
        Vector2 diff = Vector2.zero;

        if (house == null) return;

        Vector2 diffHouse = transform.position - house.position;

        if (target != null)
        {
            diff = transform.position - target.position;

            if (diffHouse.sqrMagnitude < diff.sqrMagnitude)
            {
                target = house;
                diff = diffHouse;
            }
        }
        else
        {
            target = house;
            diff = diffHouse;
        }

        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, range, mask);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sprite.rotation = Quaternion.AngleAxis(angle - offset2, Vector3.forward);

        if (diff.sqrMagnitude > range)
        {
            transform.position -= transform.TransformDirection(diff.normalized) * speed * Time.deltaTime;
        }

        if (attackTimer > attackCooldown)
        {
            if (hit.collider)
            {
                PlantBehaviour plant = hit.collider.GetComponent<PlantBehaviour>();
                HouseBehaviour house = hit.collider.GetComponent<HouseBehaviour>();

                Debug.Log(hit.collider);
                if (plant != null)
                {
                    AttackPlant(plant);
                }else if (house != null)
                {
                    AttackHouse(house);
                }
            }
        }
    }

    void AttackHouse(HouseBehaviour house)
    {
        house.TakeDamage(hitDamage);
        attackTimer = 0.0f;

    }
    void AttackPlant(PlantBehaviour plant)
    {
        plant.TakeDamage(hitDamage);
        attackTimer = 0.0f;
    }
}
