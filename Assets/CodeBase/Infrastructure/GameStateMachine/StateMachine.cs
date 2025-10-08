using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.GameStateMachine.States;

namespace CodeBase.Infrastructure.GameStateMachine
{
  public class StateMachine
  {
    private readonly Dictionary<Type, IExitState> _states;
    private IExitState _currentState;
    
    public StateMachine(SceneLoader sceneLoader)
    {
      _states = new Dictionary<Type, IExitState>()
      {
        [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
        [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader),
        [typeof(GameLoopState)] = new GameLoopState(this),
      };
    }
    
    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
    {
      IPayloadState<TPayload> state = ChangeState<TState>();
      state.Enter(payload);
    }

    private TState ChangeState<TState>() where TState : class, IExitState
    {
      _currentState?.Exit();
      TState state = GetState<TState>();
      _currentState = state;
      return state;  
    }

    private TState GetState<TState>() where TState : class, IExitState
    {
      return _states[typeof(TState)] as TState;
    }
  }
}