using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed = 10f;  // Adjust the bullet speed as needed
    public int damage = 10;  // Adjust the bullet speed as needed
    public LayerMask enemyLayer;  // The layer that represents your enemy objects

    private void Update()
    {
        MoveBullet();
        Destroy(gameObject, 5f);
    }

    private void MoveBullet()
    {
        // Move the bullet forward
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet collided with an object on the enemy layer
        if ((enemyLayer.value & 1 << other.gameObject.layer) != 0)
        {
            // Call the TakeDamage method on the enemy if it has one
            EnemyBehaviour enemy = other.GetComponent<EnemyBehaviour>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Destroy the bullet on collision
            Destroy(gameObject);
        }
    }
}
