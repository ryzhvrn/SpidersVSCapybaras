using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevelsMenu : MonoBehaviour
{
    public void OnLevelsMenuButtonPressed()
    {
        LevelsMenu.Load();
    }
}
