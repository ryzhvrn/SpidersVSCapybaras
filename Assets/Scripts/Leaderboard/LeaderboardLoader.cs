using Scripts.UI;
using UnityEngine;

namespace Scripts.Leaderboard
{
    public class LeaderboardLoader : MonoBehaviour
    {
        [SerializeField] private YandexLeaderboard _leaderboard;
        [SerializeField] private OpenLevelsMenu _levelsMenu;

        private void OnEnable()
        {
            _levelsMenu.SceneLoaded += LeaderboardOpened;
        }

        private void OnDisable()
        {
            _levelsMenu.SceneLoaded -= LeaderboardOpened;
        }

        private void LeaderboardOpened()
        {
            _leaderboard.Fill();
        }
    }
}
