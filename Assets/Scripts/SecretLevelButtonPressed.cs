using System;
using UnityEngine;

public class SecretLevelButtonPressed : MonoBehaviour
{
    public static event Action SecretLevelActivated;

    public void OnSecretLevelButtonPressed()
    {
        SecretLevelActivated.Invoke();
    }
}
