using CodeBase.Infrastructure.GameStateMachine;
using CodeBase.Infrastructure.Services.InputService;
using TMPro;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public sealed class Game
  {
    public static IInputService InputService;
    public StateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner) => 
      StateMachine = new StateMachine(new SceneLoader(coroutineRunner));
  }
}