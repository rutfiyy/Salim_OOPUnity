using UnityEngine;

public class EnemyBoss : EnemyHorizontal
{
    public GameObject bulletPrefab;  // Bullet prefab.
    public Transform bulletSpawnPoint;  // Where bullets will spawn from.
    public float shootInterval = 2f;  // How often the boss shoots.

    private float shootTimer;

    new void Start()
    {
        base.Start();  // Call base class Start method.
        shootTimer = 0;
    }

    public override void Move()
    {
        base.Move();  // Use the horizontal movement logic from EnemyHorizontal.

        // Handle shooting at intervals.
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0;
        }
    }

    private void Shoot()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            // Instantiate a bullet at the spawn point.
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }
}
