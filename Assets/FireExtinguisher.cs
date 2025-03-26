using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    public ParticleSystem particles;

    public void Shoot()
    {
        particles.Play();
    }

    public void Stop()
    {
        particles.Stop();
    }
}
