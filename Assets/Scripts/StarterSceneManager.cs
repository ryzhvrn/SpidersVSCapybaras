using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class StarterSceneManager : MonoBehaviour
{
#if UNITY_EDITOR && !UNITY_WEBGL
    private void Start()
    {
        PlayerPrefs.DeleteAll();
    }
#endif
    public void OnOpenLevelsMenuButtonPressed()
    {
        LevelsMenu.Load();
    }
}
