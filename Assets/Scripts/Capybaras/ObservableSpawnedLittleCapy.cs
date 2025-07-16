using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObservableSpawnedLittleCapy : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameEventBus _eventBus;

    private List<Capy> _childCapybaras = new List<Capy>();
    private int _distanceMultiplier = 2;

    private void Update()
    {
        CorrectChildCapybaraPosition();
    }

    private void OnEnable()
    {
        _eventBus.OnCapySpawned += OnCapySpawned;
        _eventBus.OnCapyDied += OnCapyDied;
        _eventBus.OnPlayerFinished += OnPlayerFinished;
    }

    private void OnDisable()
    {
        _eventBus.OnCapySpawned -= OnCapySpawned;
        _eventBus.OnCapyDied -= OnCapyDied;
        _eventBus.OnPlayerFinished -= OnPlayerFinished;
    }

    private void CorrectChildCapybaraPosition()
    {
        float distanceBetweenObjects = 4f;

        if (_childCapybaras.Count > 0)
        {
            foreach (Capy capy in _childCapybaras)
            {
                if (capy != null)
                {
                    capy.GetComponent<NavMeshAgent>().stoppingDistance = _distanceMultiplier * distanceBetweenObjects;
                    distanceBetweenObjects++;
                }
            }
        }
        else
        {
            return;
        }
    }

    private void OnPlayerFinished()
    {
        foreach (Capy capy in _childCapybaras)
        {
            _eventBus.Finished();
        }
    }

    private void OnCapySpawned(Capy capy)
    {
        _childCapybaras.Add(capy);
    }

    private void OnCapyDied(Capy capy)
    {
        _childCapybaras.Remove(capy);
    }
}
