using System;
using IJunior.TypedScenes;
using UnityEngine;

namespace Scripts.UI
{
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
}
