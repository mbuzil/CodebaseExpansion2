using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{
    

    public GameObject seedling;
    public Transform respawnPoint;

    public playerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.CompareTag("Spike") || other.gameObject.CompareTag("Enemy Weapon") || other.gameObject.CompareTag("Enemy"))
        {
            seedling.transform.position = respawnPoint.position;

            
        }  
    }
    

    
}
