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
        Container.Bind<GameConfig>().FromInstance(_gameConfig).AsSingle();
        Container.Bind<UIConfig>().FromInstance(_uiConfig).AsSingle();

        //Datas
        Container.Bind<GameData>().FromNew().AsSingle();

        //UIControllers
        Container.Bind<GameScreenController>().FromNew().AsSingle();
        Container.Bind<EndScreenController>().FromNew().AsSingle();

        //Managers
        Container.Bind<AsyncProcessor>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<UIManager>().FromInstance(_uiManager).AsSingle();

        //Initialize
        StartCoroutine(DelayRoutine());
    }

    IEnumerator DelayRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        _uiManager.Initialize();
    }
}