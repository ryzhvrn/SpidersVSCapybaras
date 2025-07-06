using System;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public static event Action PlayerDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            PlayerDetected?.Invoke();
        }
    }
}
