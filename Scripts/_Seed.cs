using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class _Seed : MonoBehaviour
{

   [HideInInspector] public Rigidbody2D rb;
   [HideInInspector] public CircleCollider2D collider;

   [HideInInspector] public Vector3 position { get{ return transform.position;}}


    bool isGrounded = false;
   
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
    }

    public void Push(Vector2 force)
    {
        rb.AddForce (force, ForceMode2D.Impulse);
    }

    public void ActivateRb()
    {
        rb.isKinematic = false;
    }

    public void DeactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }
    
}
