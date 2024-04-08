using UnityEngine;

public class LeaderboardLoader : MonoBehaviour
{
    [SerializeField] private YandexLeaderboard _leaderboard;

    private void OnEnable()
    {
        OpenLevelsMenu.SceneLoaded += LeaderboardOpened;
    }

    private void OnDisable()
    {
        OpenLevelsMenu.SceneLoaded -= LeaderboardOpened;
    }

    private void LeaderboardOpened()
    {
        _leaderboard.Fill();
    }
}
