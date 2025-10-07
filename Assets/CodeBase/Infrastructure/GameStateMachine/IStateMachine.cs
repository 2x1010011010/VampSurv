using CodeBase.Infrastructure.GameStateMachine.States;

namespace CodeBase.Infrastructure.GameStateMachine
{
  public interface IStateMachine
  {
    void Enter<TState>() where TState : IState;
    void Exit<TState>() where TState : IState;
  }
}