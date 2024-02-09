using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class StartChoosenLevel : MonoBehaviour
{
    public void StartFirstLevel()
    {
        Level1.Load();
        Debug.Log("Запускаем 1 уровень!");
    }

    public void StartSecondLevel()
    {
        Level2.Load();
        Debug.Log("Запускаем 2 уровень!");
    }

    public void StartThirdLevel()
    {
        Level3.Load();
        Debug.Log("Запускаем 3 уровень!");
    }

    public void OpenLeaderboard()
    {
        Leaderboard.Load();
        Debug.Log("Открыли лидерборд");
    }
}
