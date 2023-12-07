using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // ABSTRACT
    protected float forwardSpeed; // ENCAPSULATION
    protected float horizontalSpeed; // ENCAPSULATION
    protected float enemyHealth; // ENCAPSULATION
    protected bool isGoingRight = true; // ENCAPSULATION
    protected float leftTime = 0; // ENCAPSULATION
    protected float rightTime = 0; // ENCAPSULATION
    public GameObject projectile;
    public virtual void MoveEnemy()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
        if (isGoingRight)
        {
            leftTime += Time.deltaTime;
            transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
            if (leftTime > 1)
            {
                leftTime = 0;
                isGoingRight = false;
            }
        }
        else if (!isGoingRight)
        {
            rightTime += Time.deltaTime;
            transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            if (rightTime > 1)
            {
                rightTime = 0;
                isGoingRight = true;
            }
        }
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerPj"))
        {
            OnHitGoBack();
            enemyHealth -= 10;
            if (enemyHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnHitGoBack()
    {
        transform.Translate(Vector3.back * Time.deltaTime * forwardSpeed * 20);
    }

    public IEnumerator SpawnProjectile()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Instantiate(projectile, transform.position + new Vector3(0,-0.5f,0) , projectile.transform.rotation);
        }
    }
}