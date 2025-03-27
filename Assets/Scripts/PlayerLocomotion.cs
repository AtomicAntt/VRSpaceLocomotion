using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    public Vector3 velocity = Vector3.zero;
    public bool propelling = false;
    private float airResistance = 0.2f;
    private float maxVelocity = 0.6f;

    // Update is called once per frame
    public void FixedUpdate()
    {
        velocity = Vector3.ClampMagnitude(velocity, maxVelocity);

        if (!propelling)
        {
            velocity = Vector3.MoveTowards(velocity, Vector3.zero, airResistance * Time.deltaTime);

        }

        transform.position += velocity * Time.deltaTime;
    }
}
