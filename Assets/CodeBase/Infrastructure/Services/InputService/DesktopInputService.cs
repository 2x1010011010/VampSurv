using UnityEngine;

namespace CodeBase.Infrastructure.Services.InputService
{
  public class DesktopInputService : IInputService
  {
    private const string VerticalAxis = "Vertical";
    private const string HorizontalAxis = "Horizontal";
    private const string FireButton = "Fire";
    
    public Vector2 Axis => 
      new Vector2 (Input.GetAxis(HorizontalAxis), Input.GetAxis(VerticalAxis));

    public bool IsAttackButtonDown() => 
      Input.GetButtonDown(FireButton);
  }
}