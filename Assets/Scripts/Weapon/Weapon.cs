using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    public Transform parentTransform;
    public WeaponPickup weaponPickup;

    [Header("Weapon Stats")]
    [SerializeField] private float shootIntervalInSeconds = 3f;

    [Header("Bullets")]
    public Bullet bullet; // Prefab Bullet
    [SerializeField] private Transform bulletSpawnPoint; // Bullet spawn point

    [Header("Bullet Pool")]
    private IObjectPool<Bullet> objectPool;

    private readonly bool collectionCheck = false;
    private readonly int defaultCapacity = 30;
    private readonly int maxSize = 100;
    private float timer;

    void Awake()
    {
        // Initialize the bullet object pool
        objectPool = new ObjectPool<Bullet>(
            CreateBullet,
            OnGetBullet,
            OnReleaseBullet,
            OnDestroyBullet,
            collectionCheck,
            defaultCapacity,
            maxSize
        );

        // Find BulletSpawnPoint if not assigned in the Inspector
        if (bulletSpawnPoint == null)
        {
            bulletSpawnPoint = transform.Find("BulletSpawnPoint");

            if (bulletSpawnPoint == null)
            {
                Debug.LogWarning("BulletSpawnPoint not found as a child of Weapon.");
            }
            else
            {
                // Set initial position with an offset if necessary
                bulletSpawnPoint.position = new Vector3(0,1,0);
            }
        }
    }

    private Bullet CreateBullet()
    {
        Bullet newBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        newBullet.SetObjectPool(objectPool); // Assign pool to bullet
        return newBullet;
    }

    private void OnGetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true); // Activate bullet
        bullet.transform.position = bulletSpawnPoint.position;
        bullet.transform.rotation = bulletSpawnPoint.rotation;
    }

    private void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false); // Deactivate bullet
    }

    private void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject); // Destroy bullet when pool limit is reached
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Shoot at the specified interval
        if (timer >= shootIntervalInSeconds)
        {
            Shoot();
            timer = 0;
        }
    }

    public Bullet Shoot()
    {
        if (objectPool != null)
        {
            Bullet bulletInstance = objectPool.Get();
            return bulletInstance;
        }
        return null;
    }
}
