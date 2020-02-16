using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] GameConfig _gameConfig;
    [SerializeField] UIConfig _uiConfig;

    public override void InstallBindings()
    {
        var uiManager = FindObjectOfType<UIManager>();

        //Configs
        Container.BindInstance(_gameConfig).AsSingle();
        Container.BindInstance(_uiConfig).AsSingle();

        //Datas
        Container.BindInstance(new GameData()).AsSingle();

        //Managers
        Container.Bind<AsyncProcessor>().FromNewComponentOnNewGameObject().AsSingle();
        Container.BindInstance(uiManager).AsSingle();

        //Initialize
        uiManager.Initialize();
    }

    public void InstallUIController<T>(UIController<T> controller) where T : UIScreen
    {
        Container.BindInstance(controller).AsSingle();
    }
}