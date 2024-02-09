using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
   // [Header("Player Movement")]

  
    
    private Rigidbody2D rb;
    private  BoxCollider2D col;
    public Animator anim;
    public GameManager gm;

    public float speed;
    private float movementInputDirection;

    private bool isWalking;
    private bool isAiming;
    private bool isFacingRight = true;

    [SerializeField] private LayerMask WhatIsGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();

        if(Input.GetMouseButtonDown(1) && isGrounded() == true)
        {
            GetComponent<Animator>().Play("GROW");
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void CheckMovementDirection()
    {
        if(isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if(!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }

        if(rb.velocity.x > 0.5f || rb.velocity.x < -0.5f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isAiming", isAiming);

    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");
        if(gm.isDragging)
        {
            isAiming = true;
        }
        else
        {
            isAiming = false;
        }
    }

    private void ApplyMovement()
    {
        rb.velocity = new Vector2(speed * movementInputDirection, rb.velocity.y);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f,180.0f,0.0f);
    }

    public bool isGrounded()
    {
       return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, WhatIsGround);
    }



}
