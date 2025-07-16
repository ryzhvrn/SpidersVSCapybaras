using IJunior.TypedScenes;
using UnityEngine;

namespace Scripts.Services
{
    public class StarterSceneManager : MonoBehaviour
    {
        public void OnOpenLevelsMenuButtonPressed()
        {
            LevelsMenu.Load();
        }
    }
}
