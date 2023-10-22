using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantBehaviour : MonoBehaviour
{
    Vector3 worldPosition;

    [Serializable]
    public struct PlantDirection
    {
        public float from;
        public float to;
        public Sprite sprite;
    }

    public List<PlantDirection> dirs = new List<PlantDirection>();
    public float offset = 30.0f;
    public SpriteRenderer spriteRenderer;
    public int lifePoints = 100;
    public Vector2 snapedShootDir;
    private int currentDirIndex;
    public GameObject fireBall;
    public float shotCooldown;
    public float cooldownTimer;
    public float shootRange;
    public float bulletOffset;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    Vector2 GetClosestEnemy(ref float dist)
    {
        float minDist = float.MaxValue;
        Vector2 minEnemy = Vector2.zero;

        foreach (var enemy in EnemyManager.Instance.spawnedEnemies)
        {
            float currentDist = Vector2.Distance(transform.position, enemy.transform.position);
            if (currentDist < minDist)
            {
                minDist = currentDist;
                minEnemy = enemy.transform.position;
            }
        }

        dist = minDist;
        return minEnemy;
    }

    void Shoot (Vector2 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Instantiate(fireBall, (Vector2) transform.position + dir.normalized  * bulletOffset, Quaternion.AngleAxis(angle, Vector3.forward));
    }

    // Update is called once per frame
    void Update()
    {
        float enemyDist = 0.0f;
        Vector2 enemy = GetClosestEnemy(ref enemyDist);
        cooldownTimer += Time.deltaTime;

        if (enemy == Vector2.zero)
        {
            return;
        }

        Vector2 shootDir = enemy - (Vector2) transform.position;

        if(enemyDist < shootRange)
        {
            if(cooldownTimer > shotCooldown)
            {
                Shoot(shootDir);
                cooldownTimer = 0.0f;
            }
        }

        float angle = Vector2.SignedAngle(shootDir, Vector2.right) - offset;

        for (int i = 0; i < dirs.Count; i++)
        {
            if (angle > dirs[i].from && angle < dirs[i].to)
            {
                if(i != currentDirIndex)
                {
                    snapedShootDir = shootDir;
                    currentDirIndex = i;
                }

                spriteRenderer.sprite = dirs[i].sprite;
            }
        }
    }
}
