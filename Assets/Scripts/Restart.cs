using System;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public static event Action RestartCurrentLevelScene;

    public void RestartButtonPressed()
    {
        RestartCurrentLevelScene?.Invoke();
    }
}
