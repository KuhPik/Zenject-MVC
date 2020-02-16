using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class GameScreen : UIScreen
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Button _scoreButton;
    [SerializeField] private string _format = "Your score is {0}";

    public Button ScoreButton => _scoreButton;

    public void UpdateScore(int score)
    {
        _scoreText.text = string.Format(_format, score);
    }
}
