using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptButton : MonoBehaviour
{
    public static event Action AcceptButtonPressed;

    public void AcceptButtonPressedNotice()
    {
        AcceptButtonPressed?.Invoke();
    }
}
