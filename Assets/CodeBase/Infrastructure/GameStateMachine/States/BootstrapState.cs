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
      Game.InputService = RegisterInputService();
    }
    
    private static IInputService RegisterInputService()
    {
      if(Application.isMobilePlatform)
        return new MobileInputService();
      else
        return new DesktopInputService(); 
    }
  }
}