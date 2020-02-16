using System.Collections;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] GameConfig _gameConfig;
    [SerializeField] UIConfig _uiConfig;
    [SerializeField] UIManager _uiManager;

    public override void InstallBindings()
    {
        //Configs (SO is bugging...)
        Container.Bind<GameConfig>().FromInstance(_gameConfig).AsSingle().NonLazy();
        Container.Bind<UIConfig>().FromInstance(_uiConfig).AsSingle().NonLazy();

        //Datas
        Container.Bind<GameData>().FromNew().AsSingle().NonLazy();

        //Managers
        Container.Bind<AsyncProcessor>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        Container.Bind<UIManager>().FromInstance(_uiManager).AsSingle().NonLazy();

        //Initialize
        _uiManager.Initialize();
    }

    public void OnUIControllerInstantiated<T>(UIController<T> controller) where T : UIScreen
    {
        Container.Bind<UIController<T>>().FromInstance(controller).AsSingle().NonLazy();
        Container.Inject(controller);
    }
}