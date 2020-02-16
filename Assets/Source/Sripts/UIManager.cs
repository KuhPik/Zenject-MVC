using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] UIScreen[] _screens;
    [SerializeField] UIScreen _firstScreen;

    Dictionary<Type, IUIController> _screensDictionary; //Would be better with FSM?
    GameInstaller _gameInstaller;

    public void Initialize()
    {
        _screensDictionary = new Dictionary<Type, IUIController>();

        //for-loop with assembly-type factory?
        InitializeController(new GameScreenController());
        InitializeController(new EndScreenController());

        _firstScreen.SetState(true);
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

    private void InitializeController<T>(UIController<T> controller) where T : UIScreen
    {
        var screen = _screens.First(x => x.GetType() == typeof(T));
        _screensDictionary.Add(typeof(T), controller);
        controller.Initialize(screen);

        //fix?
        _gameInstaller.FindOrGet().InstallUIController(controller);
    }
}
