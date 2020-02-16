using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class EndScreen : UIScreen
{
    [SerializeField] private TextMeshProUGUI _countdownText;
    [SerializeField] private string _format = "{0} sec";

    public void UpdateTime (float time)
    {
        _countdownText.text = string.Format(_format, time.ToString("F2"));
    }
}
