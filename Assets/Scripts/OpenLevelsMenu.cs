using System;
using IJunior.TypedScenes;
using UnityEngine;

public class OpenLevelsMenu : MonoBehaviour
{
    public static event Action SceneLoaded;

    private void Start()
    {
        SceneLoaded?.Invoke();
    }

    public void OnLevelsMenuButtonPressed()
    {
        LevelsMenu.Load();
    }
}
