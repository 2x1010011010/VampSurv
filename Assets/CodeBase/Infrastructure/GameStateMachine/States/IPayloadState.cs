namespace CodeBase.Infrastructure.GameStateMachine.States
{
  public interface IPayloadState<TPayload> : IExitState
  {
    void Enter(TPayload payload);
  }
}