using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    public ParticleSystem particles;
    public AudioSource whooshSound;

    private float propelForce = 0.3f;
    private GameObject player;
    private PlayerLocomotion playerLocomotion;
    private bool activated = false;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerLocomotion = player.GetComponent<PlayerLocomotion>();
    }

    public void FixedUpdate()
    {
        if (activated)
        {
            playerLocomotion.velocity += (-particles.transform.forward) * propelForce; // player locomotion will clamp it so velocity isnt too high
            playerLocomotion.propelling = true; // in case you have two fire extinguishers at the same time? might help keep it set to true when one is stopped.
        }
    }

    public void Shoot()
    {
        activated = true;
        whooshSound.Play();
        particles.Play();
    }

    public void Stop()
    {
        activated = false;
        whooshSound.Stop();
        particles.Stop();
        playerLocomotion.propelling = false; // Reason why I call it here is because perhaps there are multiple fire extinguishers, so only if you let go of the current one will it stop.
    }
}
