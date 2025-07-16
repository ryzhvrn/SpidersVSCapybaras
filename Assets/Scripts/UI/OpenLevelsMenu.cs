using System;
using IJunior.TypedScenes;
using UnityEngine;

public class OpenLevelsMenu : MonoBehaviour
{
    public event Action SceneLoaded;

    private void Start()
    {
        SceneLoaded?.Invoke();
    }

    public void OnLevelsMenuButtonPressed()
    {
        LevelsMenu.Load();
    }
}
