using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtweenAttack;

    public Transform attackPos;
    public LayerMask whatsIsBoss;
    public float attackRangeX;
    public float attackRangeY;
    public int damage;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
       if(timeBtwAttack <= 0){
        if(Input.GetKey(KeyCode.Space))
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2 (attackRangeX, attackRangeY), 0 , whatsIsBoss);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Boss>().health -= damage; // or boss has TakeDamage(damage) function 
            }
            Debug.Log("Player is Swinging");
        }
        timeBtwAttack = startTimeBtweenAttack;

       } else
       {
        timeBtwAttack -= Time.deltaTime;
       }

       
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
