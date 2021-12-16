using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    void Start()
    {
        var emitterModule = particleSystem.emission;
        emitterModule.enabled = false;
    }

    public IEnumerator Emit()
    {
        var emitterModule = particleSystem.emission;
        emitterModule.enabled = true;
        yield return new WaitForSeconds(0.3f);
        emitterModule.enabled = false;
    }
}
