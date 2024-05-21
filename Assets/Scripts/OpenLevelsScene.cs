using System;
using UnityEngine;

public class OpenLevelsScene : MonoBehaviour
{
    public static event Action LevelsSceneActivated;

    public void OnLevelsMenuButtonPressed()
    {
        LevelsSceneActivated?.Invoke();
    }
}
