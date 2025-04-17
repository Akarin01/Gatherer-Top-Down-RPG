using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectEmitter : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectPrefab;

    private ParticleSystem _ps;
    private List<ParticleSystem.Particle> _exitParticles = new();

    private void Awake()
    {
        _ps = GetComponent<ParticleSystem>();
    }

    private void OnParticleTrigger()
    {
        _ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, _exitParticles);
        foreach (ParticleSystem.Particle p in _exitParticles)
        {
            GameObject go = Instantiate(gameObjectPrefab);
            go.transform.position = p.position;
        }
    }
}
