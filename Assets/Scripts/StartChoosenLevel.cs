using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class StartChoosenLevel : MonoBehaviour
{
    public void StartFirstLevel()
    {
        Level1.Load();
        Debug.Log("��������� 1 �������!");
    }

    public void StartSecondLevel()
    {
        Level2.Load();
        Debug.Log("��������� 2 �������!");
    }

    public void StartThirdLevel()
    {
        Level3.Load();
        Debug.Log("��������� 3 �������!");
    }

    public void StartFourthLevel()
    {
        //Level1.Load();
        Debug.Log("��������� 4 �������!");
    }

    public void StartFifthLevel()
    {
        //Level1.Load();
        Debug.Log("��������� 5 �������!");
    }
}
