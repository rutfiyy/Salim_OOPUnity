using UnityEngine;

public class EnemyTargeting : Enemy
{
    public Transform player;  // Reference to the player's transform.

    void Start()
    {
        // Spawn the enemy at a random position.
        transform.position = new Vector3(Random.Range(-8f, 8f), 6f, 0);
    }

    public override void Move()
    {
        // Move towards the player.
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    // Detect collision with player and destroy this enemy.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);  // Destroy the enemy when it hits the player.
        }
    }
}
