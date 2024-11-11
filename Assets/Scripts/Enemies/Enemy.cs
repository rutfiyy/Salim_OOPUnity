using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int level;  // Each enemy has a level.
    public Sprite enemySprite;  // Sprite for the enemy.
    protected Rigidbody2D rb;  // Rigidbody2D for movement.
    public float moveSpeed = 2f;  // Base movement speed.

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component.
        rb.gravityScale = 0;  // Disable gravity for the enemy.
    }

    // Method to set the sprite for the enemy.
    public void SetSprite(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    // Abstract method to be implemented by subclasses to define movement behavior.
    public virtual void Move()
    {
        // This will be overridden in child classes.
    }
}
