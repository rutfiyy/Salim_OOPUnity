using UnityEngine;

public class EnemyHorizontal : Enemy
{
    private bool movingRight = true;
    private Vector3 screenBounds;

    public void Start()
    {
        if (mainCamera != null)
        {
            screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        }
        else
        {
            Debug.LogError("mainCamera is not assigned in EnemyHorizontal.");
        }

        float spawnX = Random.Range(-screenBounds.x, screenBounds.x);
        transform.position = new Vector3(spawnX, transform.position.y, 0);
    }

    public override void Move()
    {
        if (mainCamera == null) return;  // Prevent movement if mainCamera is null

        rb.velocity = new Vector2(movingRight ? moveSpeed : -moveSpeed, rb.velocity.y);

        if (transform.position.x > screenBounds.x)
        {
            movingRight = false;
        }
        else if (transform.position.x < -screenBounds.x)
        {
            movingRight = true;
        }
    }
}
