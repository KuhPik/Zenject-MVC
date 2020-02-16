using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EndScreenController : UIController<EndScreen>
{
    [Inject] GameData _data;
    [Inject] UIConfig _config;
    [Inject] AsyncProcessor _processor;

    public override void Initialize(UIScreen screen)
    {
        base.Initialize(screen);
    }

    public override void Open()
    {
        base.Open();
        _processor.StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        var time = _config.RestartingTime;

        while (time > 0)
        {
            yield return null;
            time = Mathf.Clamp(time - Time.deltaTime, 0, float.PositiveInfinity);
            _view.UpdateTime(time);
        }

        _data.Restart();
    }
}
