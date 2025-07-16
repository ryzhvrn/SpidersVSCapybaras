using System;
using UnityEngine;

public class Decline : MonoBehaviour
{
    public event Action DeclineButtonPressed;

    public void Pressed()
    {
        DeclineButtonPressed?.Invoke();
    }
}
