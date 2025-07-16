using System;
using UnityEngine;

public class Accept : MonoBehaviour
{
    public event Action AcceptButtonPressed;

    public void Pressed()
    {
        AcceptButtonPressed?.Invoke();
    }
}
