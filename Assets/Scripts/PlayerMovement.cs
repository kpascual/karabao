using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public int forwardForce = 20;
    public float rotateSpeed = 10f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w")) {
            rb.AddForce(0, 0, forwardForce);
        } else if (Input.GetKey("a")) {
            transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
        } else if (Input.GetKey("d")) {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
    }
}
