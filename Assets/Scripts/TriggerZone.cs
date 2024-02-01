using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public static event Action<Capy> TriggerZoneEntered;
    public static event Action<Capy> TriggerZoneLeft;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Capy capy))
        {
            TriggerZoneEntered?.Invoke(capy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Capy capy))
        {
            TriggerZoneLeft?.Invoke(capy);
        }
    }
}
