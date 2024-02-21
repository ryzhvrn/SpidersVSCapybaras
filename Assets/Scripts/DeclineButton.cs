using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeclineButton : MonoBehaviour
{
    public static event Action DeclineButtonPressed;

    public void DeclineButtonPressedNotice()
    {
        DeclineButtonPressed?.Invoke();
    }
}
