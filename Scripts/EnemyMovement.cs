using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Enemy
{
    [SerializeField] List<Transform> wayPoints;
    [SerializeField] int wayPtIndex;
    [SerializeField] float movementSpeed, stunTime, timeTillMoveAgain;
    bool runOnce;
    float prevX;

    private void Start()
    {
        wayPtIndex = 0;
        runOnce = true;
    }

    void Update()
    {
        if(timeTillMoveAgain > 0)
        {
            timeTillMoveAgain -= Time.deltaTime;
        }
        else
        {
            if (wayPoints.Count > 0)
            {
                if (transform.position == wayPoints[wayPtIndex].position)
                {
                    float pastX = wayPoints[wayPtIndex].position.x;

                    //if at waypoint swaps to next waypoint
                    wayPtIndex++;

                    if (wayPtIndex >= wayPoints.Count)
                    {
                        wayPtIndex = 0;
                    }

                    if(pastX < wayPoints[wayPtIndex].position.x)
                    {
                        GetComponent<SpriteRenderer>().flipX = true;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().flipX = false;
                    }
                }
                else
                {
                    //else mave to waypoint
                    transform.position = Vector2.MoveTowards(transform.position, wayPoints[wayPtIndex].position, movementSpeed * Time.deltaTime);
                }
            }
            else
            {
                if (runOnce)
                {
                    Debug.LogError("Add waypoints to move");
                    runOnce = false;
                }
            }
        }
    }

    public override void StunEnemy()
    {
        timeTillMoveAgain = stunTime;
    }
}
