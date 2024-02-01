using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;

    void Update()
    {
        if (_player != null)
        {
            Vector3 directionToPlayer = _player.position - transform.position;
            transform.rotation = Quaternion.LookRotation(-directionToPlayer);
        }
    }
}
