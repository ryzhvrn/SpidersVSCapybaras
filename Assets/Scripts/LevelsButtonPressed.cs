using IJunior.TypedScenes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsButtonPressed : MonoBehaviour
{
    public static event Action LevelsSceneActivated;

    public void OnLevelsMenuButtonPressed()
    {
        LevelsSceneActivated?.Invoke();
    }
}
