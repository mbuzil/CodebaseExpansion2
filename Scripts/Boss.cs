using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float health;
    public int damage;
    private float timeBetweenDamage = 1.5f;

   // public Animator redPanel;
    // public Animator camAnim;
    public Slider healthBar;

    private void Update()
    {
        healthBar.value  = health;
    }
}
