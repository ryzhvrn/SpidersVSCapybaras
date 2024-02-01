using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capy : MonoBehaviour
{
    public static event Action<Capy> Died;

    private void OnEnable()
    {
        ObservedCapy.CapyOnFinish += OnFinish;

    }

    private void OnDisable()
    {
        ObservedCapy.CapyOnFinish -= OnFinish;

    }

    private void OnDestroy()
    {
        Debug.Log("���� ����������");
        Died?.Invoke(this);
    }

    private void OnFinish()
    {
        Debug.Log("�� ������.");
        Destroy(gameObject);
    }
}
