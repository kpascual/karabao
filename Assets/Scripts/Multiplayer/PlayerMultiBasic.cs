using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMultiBasic : NetworkBehaviour
{
    public float speed = 30;
    public Rigidbody rb;

    // need to use FixedUpdate for rigidbody
    void FixedUpdate()
    {
        // only let the local player control the racket.
        // don't control other player's rackets
        if (isLocalPlayer)
            rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.fixedDeltaTime;
    }
}
