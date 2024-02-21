using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableMouse : MonoBehaviour
{
    //private string _firstLevelName = "Level1";

    private void Start()
    {
       /* if (SceneManager.GetActiveScene().name != _firstLevelName)
        {
            HideCursor();
        }*/
    }

    private void OnEnable()
    {
        TipsButtonsController.HideCursor += HideCursor;
    }

    private void OnDisable()
    {
        TipsButtonsController.HideCursor -= HideCursor;
    }

    private void HideCursor()
    {
        Cursor.visible = false;
    }
}
