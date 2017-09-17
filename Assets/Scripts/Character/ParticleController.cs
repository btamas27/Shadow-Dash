using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public bool debug;
    ParticleSystem particle;

    public ParticleSystem Particle
    {
        get
        {
            return particle;
        }
    }

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    public void Play()
    {
        if (particle != null)
        {
            particle.Play();
        }
    }

    public void Stop()
    {
        if (particle != null && particle.isPlaying)
            particle.Stop();
    }

    public void SetForceOverLifetime(Vector3 force)
    {
        ParticleSystem.ForceOverLifetimeModule forceOverLiftime = particle.forceOverLifetime;
        forceOverLiftime.y = force.y;
    }

}
