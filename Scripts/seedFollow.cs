using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seedFollow : MonoBehaviour
{
    public float speed; // how fast it goes back to player
    public Transform seedHolder;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        seedHolder = GameObject.FindGameObjectWithTag("seedHolder").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {       
        returnSeed();
       
    }

    private void returnSeed()
    {
        
        if (Vector2.Distance(transform.position, seedHolder.position)> 0.3f)
       {
        transform.position = Vector2.Lerp(transform.position, seedHolder.position , speed * Time.deltaTime);
        //play seed Idle Animation
       } 
    }
}
