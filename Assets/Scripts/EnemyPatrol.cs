using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float patrolSpeed = 2f;

    private Transform target;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        target = pointA;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Move the enemy towards the current target
        transform.position = Vector2.MoveTowards(transform.position, target.position, patrolSpeed * Time.deltaTime);

        // Check if the enemy has reached the current target
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            // If the current target is pointA, switch to pointB; otherwise, switch to pointA
            target = (target == pointA) ? pointB : pointA;

            // Flip the sprite based on the direction of movement
            FlipSprite();
        }
    }

    void FlipSprite()
    {
        // Flip the sprite based on the direction of movement
        if (transform.position.x < target.position.x)
        {
            spriteRenderer.flipX = true; // Not flipped
        }
        else
        {
            spriteRenderer.flipX = false; // Flipped
        }
    }
}
