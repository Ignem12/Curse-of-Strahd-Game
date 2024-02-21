using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovt : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float input;
    public SpriteRenderer sprite;
    public float jumpForce = 1f;
    public LayerMask groundLayer;
    public bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;
    public Animator animator;

    public float timeinair = 0;
    public float deathtimer = 15;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(input * speed));
        input = Input.GetAxisRaw("Horizontal");
        if (input < 0)
        {
            sprite.flipX = true;
        }

        else if (input > 0)
        {
            sprite.flipX = false;
        }

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        if (isGrounded == true && !Input.GetButton("Jump"))
        {
            animator.SetBool("isJumping", false);
        }

        if (isGrounded == true && Input.GetButton("Jump"))
        {
            animator.SetBool("isJumping", true);
            rb.velocity = Vector2.up * jumpForce;
        }

        if (!isGrounded)
        {
            timeinair += Time.deltaTime;
        }

        else
        {
            timeinair = 0;
        }

        if (timeinair >= deathtimer)
        {
            RestartLevel();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
