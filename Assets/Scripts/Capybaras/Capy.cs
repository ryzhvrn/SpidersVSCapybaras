using System;
using UnityEngine;

public class Capy : MonoBehaviour
{
    private GameEventBus _eventBus;

    private void Awake()
    {
        _eventBus = FindObjectOfType<GameEventBus>();
    }

    private void OnEnable()
    {
        _eventBus.OnFinished += OnFinish;
    }

    private void OnDisable()
    {
        _eventBus.OnFinished -= OnFinish;
    }

    private void OnDestroy()
    {
        _eventBus?.CapyDied(this);
    }

    private void OnFinish()
    {
        Destroy(gameObject);
    }
}
