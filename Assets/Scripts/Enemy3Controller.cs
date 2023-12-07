using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Controller : EnemyMovement 
{
    // INHERITANCE
    private void Start()
    {
        forwardSpeed = 40f;
        horizontalSpeed = 30f;
        enemyHealth = 10f;
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
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}