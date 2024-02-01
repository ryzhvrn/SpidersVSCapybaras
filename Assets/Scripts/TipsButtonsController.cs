using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsButtonsController : MonoBehaviour
{
    [SerializeField] private Image _tipsBackground;
    [SerializeField] private Button _nextButton;
    [SerializeField] private List<Text> _tipsList;

    private int _counter = 0;

    public void OnButtonClick()
    {
        ShowNextTip();
    }

    private void ShowNextTip()
    {
        DisableText();
        _counter++;
        EnableText();
        DisableTipsBackground();
        DisableTipsNextButton();
    }

    private void EnableText()
    {
        if (_counter < _tipsList.Count)
        {
            _tipsList[_counter].gameObject.SetActive(true);
        }
    }

    private void DisableText()
    {
        if (_counter < _tipsList.Count)
        {
            _tipsList[_counter].gameObject.SetActive(false);
        }
    }

    private void DisableTipsBackground()
    {
        if (_counter == _tipsList.Count)
        {
            _tipsBackground.gameObject.SetActive(false);
        }
    }

    private void DisableTipsNextButton()
    {
        if (_counter == _tipsList.Count)
        {
            _nextButton.gameObject.SetActive(false);
        }
    }
}
