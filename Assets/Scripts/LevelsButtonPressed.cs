using System;
using UnityEngine;

public class LevelsButtonPressed : MonoBehaviour
{
    public static event Action LevelsSceneActivated;

    public void OnLevelsMenuButtonPressed()
    {
        LevelsSceneActivated?.Invoke();
    }
}
