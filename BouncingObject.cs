using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingObject : MonoBehaviour
{
    public float bounceForce = 5.0f; // Adjust the force as needed

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a GameObject that has a Rigidbody
        if (collision.gameObject.GetComponent<Rigidbody>())
        {
            // Calculate the bounce direction
            Vector3 bounceDirection = (transform.position - collision.contacts[0].point).normalized;

            // Apply the bounce force
            collision.gameObject.GetComponent<Rigidbody>().velocity = bounceDirection * bounceForce;
        }
    }
}
