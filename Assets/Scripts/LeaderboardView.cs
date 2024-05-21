using System.Collections.Generic;
using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    private List<LeaderboardElement> _spawnedElements = new ();

    [SerializeField] private Transform _container;
    [SerializeField] private LeaderboardElement _leaderboardElementPrefab;

    private void ClearLeaderboard()
    {
        foreach (var element in _spawnedElements)
        {
            Destroy(element);
        }
    }

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
}
