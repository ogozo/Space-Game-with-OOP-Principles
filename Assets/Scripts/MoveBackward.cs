using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackward : MonoBehaviour
{
    Rigidbody rb;
    float addForce = 20f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.AddForce(Vector3.back * addForce, ForceMode.Impulse);
        if (transform.position.z < -100)
        {
            Destroy(gameObject);
        }
    }
}
