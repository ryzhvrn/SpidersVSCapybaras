using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Leaderboard
{
    public class LeaderboardView : MonoBehaviour
    {
        private List<LeaderboardElement> _spawnedElements = new List<LeaderboardElement>();

        [SerializeField] private Transform _container;
        [SerializeField] private LeaderboardElement _leaderboardElementPrefab;

        public void ConstructLeaderboard(List<LeaderboardPlayer> leaderboardPlayers)
        {
            ClearLeaderboard();

            foreach (LeaderboardPlayer player in leaderboardPlayers)
            {
                LeaderboardElement leaderboardElementInstance = Instantiate(_leaderboardElementPrefab, _container);
                leaderboardElementInstance.Initialize(player.Name, player.Rank, player.Score);
                _spawnedElements.Add(leaderboardElementInstance);
            }
        }

        private void ClearLeaderboard()
        {
            foreach (var element in _spawnedElements)
            {
                Destroy(element);
            }
        }
    }
}
