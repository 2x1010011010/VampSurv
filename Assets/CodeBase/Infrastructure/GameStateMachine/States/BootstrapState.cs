using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.AssetManagement;
using CodeBase.Infrastructure.Services.Factories;
using CodeBase.Infrastructure.Services.InputService;
using UnityEngine;

namespace CodeBase.Infrastructure.GameStateMachine.States
{
  public class BootstrapState : IState
  {
    private readonly StateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    
    public BootstrapState(StateMachine stateMachine, SceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    } 

    public void Enter()
    {
      RegisterServices();
      _sceneLoader.Load(sceneName: Constants.InitialScene, onLoaded: EnterLoadLevel);
    }

    public void Exit()
    {
      
    }

    private void EnterLoadLevel() => 
      _stateMachine.Enter<LoadLevelState, string>(Constants.GameScene);

    private void RegisterServices()
    {
      Game.InputService = InputService();

      ServiceLocator.Container.RegisterSingle<IInputService>(InputService());
      ServiceLocator.Container.RegisterSingle<IGameFactory>(new GameFactory(ServiceLocator.Container.Single<IAssetProvider>()));
    }
    
    private static IInputService InputService()
    {
      if(Application.isMobilePlatform)
        return new MobileInputService();
      else
        return new DesktopInputService(); 
    }
  }
}