namespace CodeBase.Infrastructure.GameStateMachine.States
{
  public class GameLoopState : IState
  {
    private readonly StateMachine _stateMachine;

    
    public GameLoopState(StateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }

    public void Enter()
    {

    }

    public void Exit()
    {

    }
  }
}