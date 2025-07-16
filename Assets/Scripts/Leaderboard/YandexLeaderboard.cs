using System.Collections.Generic;
using Agava.YandexGames;
using UnityEngine;

namespace Scripts.Leaderboard
{
    public class YandexLeaderboard : MonoBehaviour
    {
        private const string EnglishAnonymousName = "Anonymous";
        private const string RussianAnonymousName = "Анонимный";
        private const string TurkishAnonymousName = "Anonim";
        private const string LeaderboardName = "Leaderboard";
        [SerializeField] private LeaderboardView _leaderboardView;
        private readonly List<LeaderboardPlayer> _leaderboardPlayers = new List<LeaderboardPlayer>();

        public void SetPlayerScore(int score)
        {
            if (PlayerAccount.IsAuthorized == false)
            {
                return;
            }

            Agava.YandexGames.Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
            {
                if (result.score < score)
                {
                    Agava.YandexGames.Leaderboard.SetScore(LeaderboardName, score);
                }
            });
        }

        public void Fill()
        {
            _leaderboardPlayers.Clear();

            if (PlayerAccount.IsAuthorized == false)
            {
                return;
            }

            Agava.YandexGames.Leaderboard.GetEntries(LeaderboardName, result =>
            {
                foreach (var entry in result.entries)
                {
                    var rank = entry.rank;
                    var score = entry.score;
                    var name = entry.player.publicName;

                    if (string.IsNullOrEmpty(name))
                    {
                        string currentLanguage = YandexGamesSdk.Environment.i18n.lang;

                        switch (currentLanguage)
                        {
                            case "Russian":
                                name = RussianAnonymousName;
                                break;

                            case "English":
                                name = EnglishAnonymousName;
                                break;

                            case "Turkish":
                                name = TurkishAnonymousName;
                                break;
                        }
                    }

                    _leaderboardPlayers.Add(new LeaderboardPlayer(rank, name, score));
                }

                _leaderboardView.ConstructLeaderboard(_leaderboardPlayers);
            });
        }
    }
}
