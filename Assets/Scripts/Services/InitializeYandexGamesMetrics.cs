using UnityEngine;

namespace Scripts.Services
{
    public class InitializeYandexGamesMetrics : MonoBehaviour
    {
        private void Start()
        {
#if !UNITY_EDITOR && UNITY_WEBGL
        YandexGamesSdk.GameReady();
#endif
        }
    }
}
