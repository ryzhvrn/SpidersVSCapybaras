using System;
using UnityEngine;

public class Capy : MonoBehaviour
{
    private GameEventBus _eventBus;
    
    //public static event Action<Capy> Died;

    private void Awake()
    {
        _eventBus = FindObjectOfType<GameEventBus>();
    }

    private void OnEnable()
    {
        _eventBus.OnFinished += OnFinish;
        //ObservableSpawnedLittleCapy.Finished += OnFinish;
    }

    private void OnDisable()
    {
        _eventBus.OnFinished -= OnFinish;
        //ObservableSpawnedLittleCapy.Finished -= OnFinish;
    }

    private void OnDestroy()
    {
        _eventBus?.CapyDied(this);
        //Died?.Invoke(this);
    }

    private void OnFinish()
    {
        Destroy(gameObject);
    }
}
