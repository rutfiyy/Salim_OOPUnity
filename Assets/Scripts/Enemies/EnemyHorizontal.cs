using UnityEngine;

public class EnemyHorizontalMovement : Enemy
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 dir;
    private bool movingRight;
    private Vector3 screenBounds;
    private Rigidbody2D rb;
    [SerializeField] Camera mainCamera;

    private void Awake()
    {
        if (mainCamera != null)
        {
            rb = GetComponent<Rigidbody2D>();
            // Menentukan arah spawn
            movingRight = Random.value > 0.5f;

            // Menentukan posisi spawn
            float spawnY = Random.Range(Screen.height / 2, Screen.height-50);
            float spawnX = movingRight ? Screen.width + 50 : -50;
            Vector3 spawnPosition = mainCamera.ScreenToWorldPoint(new Vector3(spawnX, spawnY, mainCamera.transform.position.z));
            transform.position = new Vector3(spawnPosition.x, spawnPosition.y, 0);

            // Memberikan batas layar game
            screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        }
        else
        {
            Debug.LogError(this + " tidak memiliki MainCamera");
        }
    }

    private void Update()
    {
        if (mainCamera == null) return; // EnemyHorizontal tidak bergerak jika tidak memiliki MainCamera

        // Menentukan kecepatan berdasarkan arah gerakan
        if (movingRight)
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector2.right);
        }else
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector2.left);
        }

        // Mengbah arah gerakan jika menyentuh batas layar
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
