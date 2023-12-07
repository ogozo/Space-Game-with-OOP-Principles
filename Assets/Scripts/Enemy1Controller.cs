using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : EnemyMovement
{
    // INHERITANCE
    private void Start()
    {
        forwardSpeed = 30f;
        horizontalSpeed = 20f;
        enemyHealth = 30f;
        StartCoroutine(SpawnProjectile());

    }

    private void Update()
    {
        MoveEnemy();
        if (transform.position.z < -160)
        {
            Destroy(gameObject);
        }
    }
    // POLYMORPHISM
    public override void MoveEnemy()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
        if (isGoingRight)
        {
            leftTime += Time.deltaTime;
            transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            if (leftTime > 1)
            {
                leftTime = 0;
                isGoingRight = false;
            }
        }
        else if (!isGoingRight)
        {
            rightTime += Time.deltaTime;
            transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
            if (rightTime > 1)
            {
                rightTime = 0;
                isGoingRight = true;
            }
        }
    }
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}