using System;
using UnityEngine;

public class Capy : MonoBehaviour
{
    public static event Action<Capy> Died;

    private void OnEnable()
    {
        ObservableSpawnedLittleCapy.Finished += OnFinish;
    }

    private void OnDisable()
    {
        ObservableSpawnedLittleCapy.Finished -= OnFinish;
    }

    private void OnDestroy()
    {
        Died?.Invoke(this);
    }

    private void OnFinish()
    {
        Destroy(gameObject);
    }
}
