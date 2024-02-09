using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] bool bezier, shotFired;
    [SerializeField] List<Vector2> posittion;
    //Of note posittions is reletive to the enemie's position also put last position slightly in the ground
    [SerializeField] float shotCycle, speed;
    [SerializeField] Collider2D collider;
    [SerializeField] SpriteRenderer renderer;

    void Start()
    {
        //deactivate the object
        collider.enabled = false;
        renderer.enabled = false;
        shotFired = false;
    }

    void Update()
    {
        if (shotFired)
        {
            AudioSource source = GetComponent<AudioSource>();
            source.Play();
            shotCycle += speed * Time.deltaTime; //determins t for Bezier and Lerp

            if (bezier)
            {
                //moves along curve
                transform.localPosition = Bezier(shotCycle, posittion[0], posittion[1], posittion[2]);
            }
            else
            {
                //moves along straight line
                transform.localPosition = Vector2.Lerp(posittion[0], posittion[1], shotCycle);
            }
        }
    }

    Vector2 Bezier(float t, Vector2 a, Vector2 b, Vector2 c)
    {
        Vector2 ab = Vector2.Lerp(a, b, t);
        Vector2 bc = Vector2.Lerp(b, c, t);
        return Vector2.Lerp(ab, bc, t);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Enemy Weapon")
        {
            Debug.Log("Hit");
            //deactivate the object
            collider.enabled = false;
            renderer.enabled = false;
            shotFired = false;
        }
    }

    public void RestBullet()
    {

        Debug.Log("shoot");
        transform.position = posittion[0];
        shotCycle = 0;
        collider.enabled = true;
        renderer.enabled = true;
        shotFired = true;
    }

    public bool IsShooting()
    {
        return shotFired;
    }
}
