using UnityEngine;

public class EnemyHorizontal : Enemy
{
    private bool movingRight = true;

    public void Start()
    {
        // Randomly choose spawn position (left or right of the screen).
        float spawnX = Random.Range(-8f, 8f);
        transform.position = new Vector3(spawnX, transform.position.y, 0);
    }

    // Override the Move method to implement horizontal movement.
    public override void Move()
    {
        if (movingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);  // Move to the right.
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);  // Move to the left.
        }

        // Reverse direction if out of bounds.
        if (transform.position.x > 8f)
        {
            movingRight = false;
        }
        else if (transform.position.x < -8f)
        {
            movingRight = true;
        }
    }
}
