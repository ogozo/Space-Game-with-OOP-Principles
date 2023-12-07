using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : EnemyMovement
{
    // INHERITANCE
    private void Start()
    {
        forwardSpeed = 35f;
        horizontalSpeed = 25f;
        enemyHealth = 20f;
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
