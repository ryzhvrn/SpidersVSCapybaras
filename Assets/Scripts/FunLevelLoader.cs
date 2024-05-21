using IJunior.TypedScenes;
using UnityEngine;

public class FunLevelLoader : MonoBehaviour
{
    private void OnEnable()
    {
        OpenLevelsScene.LevelsSceneActivated += OnLevelsSceneActivated;
    }

    private void OnDisable()
    {
        OpenLevelsScene.LevelsSceneActivated -= OnLevelsSceneActivated;
    }

    private void OnLevelsSceneActivated()
    {
        LevelsMenu.Load();
    }
}
