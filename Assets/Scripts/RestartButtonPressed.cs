using System;
using UnityEngine;

public class RestartButtonPressed : MonoBehaviour
{
    public static event Action RestartCurrentLevelScene;

    public void OnRestartButtonPressed()
    {
        RestartCurrentLevelScene?.Invoke();
    }
}
