using UnityEngine;

public class EnemyForward : Enemy
{
    void Start()
    {
        transform.position = new Vector3(Random.Range(-8f, 8f), 6f, 0);
    }

    public override void Move()
    {
        rb.velocity = new Vector2(0, -moveSpeed);
    }
}
