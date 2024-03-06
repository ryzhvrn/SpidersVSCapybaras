using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFunManager : MonoBehaviour
{
    private void OnEnable()
    {
        LevelsButtonPressed.LevelsSceneActivated += LoadLevelsMenuScene;
    }

    private void OnDisable()
    {
        LevelsButtonPressed.LevelsSceneActivated -= LoadLevelsMenuScene;
    }

    private void LoadLevelsMenuScene()
    {
        LevelsMenu.Load();
    }
}
