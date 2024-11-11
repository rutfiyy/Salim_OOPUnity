using UnityEngine;

public class EnemyForward : Enemy
{
    void Start()
    {
        // Spawn the enemy at a random x position at the top of the screen.
        transform.position = new Vector3(Random.Range(-8f, 8f), 6f, 0);
    }

    public override void Move()
    {
        rb.velocity = new Vector2(0, -moveSpeed);  // Move downward.
    }
}
