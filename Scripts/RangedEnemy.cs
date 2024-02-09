using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] bool moves;
    [SerializeField] List<Transform> wayPoints;
    [SerializeField] int wayPtIndex;
    [SerializeField] float movementSpeed, stunTime;
    [Space]
    [SerializeField] bool canBeStuned, shoots;
    [SerializeField] EnemyBullet bullet;
    [SerializeField] float timeBetweenShots;
    [SerializeField] float countdownTillMoveAgain, countdownTillShoot;

    private void Start()
    {
        wayPtIndex = 0;
    }

    void Update()
    {
        if (countdownTillMoveAgain > 0)
        {
            countdownTillMoveAgain -= Time.deltaTime;
        }
        else
        {

            //Movement
            if (moves)
            {
                if (transform.position == wayPoints[wayPtIndex].position)
                {
                    //if at waypoint swaps to next waypoint
                    wayPtIndex++;

                    if (wayPtIndex >= wayPoints.Count)
                    {
                        //resets waypoints
                        wayPtIndex = 0;
                    }
                }
                else
                {
                    //else mave to waypoint
                    transform.position = Vector2.MoveTowards(transform.position, wayPoints[wayPtIndex].position, movementSpeed * Time.deltaTime);
                }
            }

            //Shooting
            if (shoots)
            {
                //shoots when the bullet is inactive and colldown is pased
                if (countdownTillShoot < 0 && !bullet.IsShooting())
                {
                    //Resets the bullet
                    bullet.RestBullet();
                    countdownTillShoot = timeBetweenShots;

                }
                else
                {
                    countdownTillShoot -= Time.deltaTime;

                }
            }
        }
    }

    public override void StunEnemy()
    {
        //stuns enemy for stunTime
        if (canBeStuned)
            countdownTillMoveAgain = stunTime;
    }
}
