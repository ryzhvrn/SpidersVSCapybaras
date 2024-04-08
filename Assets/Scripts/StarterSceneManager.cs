using UnityEngine;
using IJunior.TypedScenes;

public class StarterSceneManager : MonoBehaviour
{
    public void OnOpenLevelsMenuButtonPressed()
    {
        LevelsMenu.Load();
    }
}
