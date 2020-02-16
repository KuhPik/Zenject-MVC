using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class UIManager : MonoBehaviour
{
    [Inject] GameScreenController _gameScreenController;
    [Inject] EndScreenController _endScreenController;

    [SerializeField] UIScreen[] _screens;
    [SerializeField] UIScreen _firstScreen;

    Dictionary<Type, IUIController> _screensDictionary; //Would be better with FSM?

    public void Initialize()
    {
        _screensDictionary = new Dictionary<Type, IUIController>();
        _firstScreen.SetState(true);

        InitializeController(_gameScreenController);
        InitializeController(_endScreenController);
    }

    public void OpenScreen<T>(bool closeOthers = true) where T : UIScreen
    {
        if (closeOthers)
        {
            foreach (var controller in _screensDictionary.Values)
            {
                controller.Close();
            }

            _screensDictionary[typeof(T)].Open();
        }
    }

    public void InitializeController<T>(UIController<T> controller) where T : UIScreen
    {
        var screen = _screens.First(x => x.GetType() == typeof(T));
        _screensDictionary.Add(typeof(T), controller);
        controller.Initialize(screen);
    }
}
