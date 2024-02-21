using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private SpriteRenderer sprite;
    private Animator anim;
    public float speed = 7f;
    private float dirX = 0f;
    private enum movementState { idle, running, jumping, falling };
    // Start is called before the first frame update
    private movementState state = movementState.idle;
    [SerializeField] private LayerMask JumpableGround;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 14f);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (dirX < 0f)
        {
            state = movementState.running;
            sprite.flipX = true;
        }

        else if (dirX > 0f)
        {
            state = movementState.running;
            sprite.flipX = false;
        }

        else
        {
            state = movementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = movementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = movementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
    }
}
