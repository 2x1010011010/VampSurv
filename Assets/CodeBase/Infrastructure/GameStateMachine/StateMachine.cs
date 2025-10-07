using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.GameStateMachine.States;

namespace CodeBase.Infrastructure.GameStateMachine
{
  public class StateMachine : IStateMachine
  {
    private Dictionary<Type, IState> _states;
    private IState _currentState;
    
    public StateMachine(SceneLoader sceneLoader)
    {
      _states = new Dictionary<Type, IState>()
      {
        [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
      };
    }
    
    public void Enter<TState>() where TState : IState
    {
      _currentState?.Exit();
      IState state = _states[typeof(TState)];
      _currentState = state;
      _currentState.Enter();
    }

    public void Exit<TState>() where TState : IState
    {
      throw new System.NotImplementedException();
    }
  }
}