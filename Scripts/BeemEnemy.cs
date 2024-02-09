using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeemEnemy : Enemy
{
    [SerializeField] float stunTime;
    [SerializeField] GameObject beem;
    float countdownTillBeem;

    void Start()
    {
        
    }

    void Update()
    {

        if (countdownTillBeem < 0 && !beem.active)
        {
            //restart beem
            beem.SetActive(true);
        }
        else
        {
        }

        if (countdownTillBeem > 0 && beem.active)
        {
            StunEnemy();
        }
        //else beem is off
    }

    public override void StunEnemy()
    {
        countdownTillBeem = stunTime;
        beem.SetActive(false);
    }
}
