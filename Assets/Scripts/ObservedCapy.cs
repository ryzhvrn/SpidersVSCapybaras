using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ProBuilder.Shapes;

public class ObservedCapy : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private List<Capy> _childCapybaras = new List<Capy>();
    private int _distanceMultiplier = 2;

    public static event Action CapyOnFinish;

    private void Update()
    {
        CorrectChildCapybaraPosition();
    }

    private void OnEnable()
    {
        Spawner.ChildCapybaraSpawned += OnChildCapybaraSpawned;
        Capy.Died += OnChildCapybaraDied;
        Finish.PlayerFinished += OnPlayerFinished;
    }

    private void OnDisable()
    {
        Spawner.ChildCapybaraSpawned -= OnChildCapybaraSpawned;
        Capy.Died -= OnChildCapybaraDied;
        Finish.PlayerFinished -= OnPlayerFinished;
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
            CapyOnFinish?.Invoke();
        }
    }

    private void OnChildCapybaraSpawned(Capy capy)
    {
        _childCapybaras.Add(capy);
    }

    private void OnChildCapybaraDied(Capy capy)
    {
        _childCapybaras.Remove(capy);
    }
}
