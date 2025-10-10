using CodeBase.GameLogic.CameraLogic;
using CodeBase.Infrastructure.Factories;
using UnityEngine;

namespace CodeBase.Infrastructure.GameStateMachine.States
{
  public class LoadLevelState : IPayloadState<string>
  {
    private readonly SceneLoader _sceneLoader;
    private readonly StateMachine _stateMachine;
    private readonly IGameFactory _gameFactory;
    
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
      var character = _gameFactory.CreatePlayer
        (
          GameObject.FindGameObjectWithTag
            (Constants.SpawnPointTag)
            .transform
        );
      
      character.transform.SetParent(null);

      _gameFactory.CreateHud();
      
      CameraSetup(character);
      
      _stateMachine.Enter<GameLoopState>();
    }
    
    private void CameraSetup(GameObject target)
    {
      var camera = Camera.main;

      var cameraFollow = camera?.GetComponent<CameraFollow>();
      if (cameraFollow == null) return;
      if (cameraFollow.Target == null)
        cameraFollow.SetTarget(target);
    }
  }
}