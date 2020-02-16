using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameScreenController : UIController<GameScreen>
{
    [Inject] GameConfig _config;
    [Inject] GameData _data;

    public override void Initialize(UIScreen screen)
    {
        base.Initialize(screen);
        _view.UpdateScore(0);

        _view.ScoreButton.onClick.AddListener(() => AddScore());
        _view.ScoreButton.onClick.AddListener(() => UpdateText());
    }

    void AddScore()
    {
        _data.UpdateScore(_config.TapScore);
    }

    void UpdateText()
    {
        _view.UpdateScore(_data.GetScore());
    }
}
