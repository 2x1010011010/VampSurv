using CodeBase.GameLogic.CameraLogic;
using UnityEngine;

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
      var spawnPoint = GameObject.FindGameObjectWithTag(Constants.SpawnPointTag);
      var character = Instantiate(Constants.CharacterPath, at: spawnPoint.transform);
      character.transform.SetParent(null);
      
      Instantiate(Constants.HUD);
      
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

    private static GameObject Instantiate(string path)
    {
      var prefab = Resources.Load<GameObject>(path);
      return Object.Instantiate(prefab);
    }
    
    private static GameObject Instantiate(string path, Transform at)
    {
      var prefab = Resources.Load<GameObject>(path);
      return Object.Instantiate(prefab, at);
    }
  }
}