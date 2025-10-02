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

    public Vector3? LookDirection
    {
      get
      {
        Camera camera = Camera.main;
        if (camera == null)
          return null;

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);

        if (plane.Raycast(ray, out float distance))
          return ray.GetPoint(distance);

        return null;
      }
    }

    public bool IsAttackButtonDown() => 
      Input.GetButtonDown(FireButton);
  }
}