using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class StarterSceneManager : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    public void OnOpenLevelsMenuButtonPressed()
    {
        LevelsMenu.Load();
    }
}
