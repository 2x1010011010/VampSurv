namespace CodeBase.Infrastructure.GameStateMachine.States
{
  public class LoadLevelState : IPayloadState<string>
  {
    private readonly SceneLoader _sceneLoader;
    private readonly StateMachine _stateMachine;
    
    public LoadLevelState(StateMachine stateMachine, SceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }
    
    public void Enter(string sceneName) => 
      _sceneLoader.Load(sceneName, OnLoaded);

    public void Exit()
    {
      
    }

    private void OnLoaded()
    {
      //Spawn hero + HUD from prefabs
    }
  }
}