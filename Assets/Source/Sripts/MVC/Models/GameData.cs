using Zenject;
using UnityEngine.SceneManagement;
using UnityEngine;

public sealed class GameData
{
    [Inject] GameConfig _config;
    [Inject] UIManager _uiManager;

    int _score;
    bool isRestarting;

    public void UpdateScore(int score)
    {
        _score += score;

        if (_score >= _config.MaxScore)
        {
            _uiManager.OpenScreen<EndScreen>();
        }
    }

    public void Restart()
    {
        isRestarting = true;
        SceneManager.LoadScene(0);
    }

    public bool GetState() => !isRestarting;
    public int  GetScore() => _score;
}
