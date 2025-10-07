using CodeBase.Infrastructure.GameStateMachine.States;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public sealed class Bootstrapper : MonoBehaviour, ICoroutineRunner
  {
    private Game _game;

    private void Awake()
    {
      _game = new Game(this);
      _game.StateMachine.Enter<BootstrapState>();
      
      DontDestroyOnLoad(this);
    }
  }
}