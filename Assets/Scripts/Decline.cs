using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decline : MonoBehaviour
{
    public static event Action DeclineButtonPressed;

    public void DeclineButtonPressedNotice()
    {
        DeclineButtonPressed?.Invoke();
    }
}
