using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class StarterSceneManager : MonoBehaviour
{
    public void OnOpenLevelsMenuButtonPressed()
    {
        LevelsMenu.Load();
    }
}
