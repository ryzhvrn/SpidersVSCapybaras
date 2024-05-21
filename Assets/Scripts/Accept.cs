using System;
using UnityEngine;

public class Accept : MonoBehaviour
{
    public static event Action AcceptButtonPressed;

    public void AcceptButtonPressedNotice()
    {
        AcceptButtonPressed?.Invoke();
    }
}
