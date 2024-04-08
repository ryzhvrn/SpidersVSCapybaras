using IJunior.TypedScenes;
using UnityEngine;

public class LevelFunManager : MonoBehaviour
{
    private void OnEnable()
    {
        LevelsButtonPressed.LevelsSceneActivated += OnLevelsSceneActivated;
    }

    private void OnDisable()
    {
        LevelsButtonPressed.LevelsSceneActivated -= OnLevelsSceneActivated;
    }

    private void OnLevelsSceneActivated()
    {
        LevelsMenu.Load();
    }
}
