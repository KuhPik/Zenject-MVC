using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class UIManager : MonoBehaviour
{
    [SerializeField] UIScreen[] _screens;
    [SerializeField] UIScreen _firstScreen;

    Dictionary<Type, IUIController> _screensDictionary = new Dictionary<Type, IUIController>(); //Would be better with FSM?
    GameInstaller _gameInstaller;

    public void Initialize()
    {
        _firstScreen.SetState(true);

        InitializeController(new GameScreenController());
        InitializeController(new EndScreenController());
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

        _gameInstaller.FindOrGet().OnUIControllerInstantiated(controller);
    }
}
