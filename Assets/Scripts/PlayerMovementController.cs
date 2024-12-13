using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerMovementController : MonoBehaviour
{
    public float moveSpeed = 5f;           // Velocidade de movimento
    public float jumpForce = 10f;          // Força do pulo
    public Animator animator;              // Controlador de animações
    public Rigidbody2D rb;

    private bool isJumping = false;        // Controle se o personagem está pulando
    private float horizontalInput = 0f;    // Valor de entrada para a direção horizontal

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public void PressLeft()
    {
        horizontalInput = -1f; 
    }
    public void PressRight()
    {
        horizontalInput = 1f;
    }
    public void ReleaseMove()
    {
        horizontalInput = 0f;
    }

    // Update is called once por frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            PressLeft();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            ReleaseMove();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PressRight();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            ReleaseMove();
        }

        animator.SetFloat("Run", Mathf.Abs(horizontalInput));
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-10, 10, 1);
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(10, 10, 1);
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }
    public void Jump()
    { 
            if (!isJumping)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                isJumping = true;
                animator.SetTrigger("Jump");
            }  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }
    }
}
