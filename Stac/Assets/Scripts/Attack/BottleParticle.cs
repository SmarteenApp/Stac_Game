using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleParticle : MonoBehaviour
{
    ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(particle != null)
        {
            ParticleSystem.MainModule main = particle.main;

            if(main.startRotation.mode == ParticleSystemCurveMode.Constant)
            {
                main.startRotation = -transform.eulerAngles.z * Mathf.Deg2Rad;
            }
        }
    }
}
