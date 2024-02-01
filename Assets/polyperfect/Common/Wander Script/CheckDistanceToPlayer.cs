using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistanceToPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    public static event Action<bool> PlayerDetected;

    private void Start()
    {
        StartCoroutine(CheckPlayerDistance());
    }

    private IEnumerator CheckPlayerDistance()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            float distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);

            if (distanceToPlayer > 15f)
            {
                PlayerDetected?.Invoke(false);
                //Debug.Log("Расстояние до игрока больше 3f");
                //Debug.Log(distanceToPlayer + "у.е.");

            }
            else
            {
                PlayerDetected?.Invoke(true);
                //Debug.Log("Расстояние до игрока меньше или равно 3f");
                //Debug.Log(distanceToPlayer + "у.е.");

            }
        }
    }
}
