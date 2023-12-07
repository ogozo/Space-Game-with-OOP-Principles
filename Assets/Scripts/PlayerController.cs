using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 100f;
    public GameObject projectile;
    float playerHealth = 50;
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootProjectile();
        }

        if(transform.position.x > 90)
        {
            transform.position = new Vector3(90, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -90)
        {
            transform.position = new Vector3(-90, transform.position.y, transform.position.z);
        }


    }  
    void ShootProjectile()
    {
        Instantiate(projectile, transform.position + new Vector3(0,-0.5f,0), projectile.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyPj"))
        {
            playerHealth -= 10;
            if(playerHealth == 0) {
                Destroy(gameObject);
            }
        }
    }
}