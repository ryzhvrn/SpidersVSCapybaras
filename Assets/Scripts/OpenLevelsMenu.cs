using IJunior.TypedScenes;
using System;
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
