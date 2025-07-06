using System;
using UnityEngine;

public class Decline : MonoBehaviour
{
    public static event Action DeclineButtonPressed;

    public void DeclineButtonPressedNotice()
    {
        DeclineButtonPressed?.Invoke();
    }
}
