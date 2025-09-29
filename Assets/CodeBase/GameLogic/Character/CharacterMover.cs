using CodeBase.GameLogic.CameraLogic;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Services.InputService;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.GameLogic.Character
{
  public class CharacterMover : MonoBehaviour
  {
    [SerializeField, BoxGroup("CONTROLLER SETUP")] private float _movementSpeed = 10f;
    [SerializeField, BoxGroup("CONTROLLER SETUP")] private float _movementEpsilon = 0.001f;
    [SerializeField, BoxGroup("CONTROLLER SETUP")] private float _rotationSpeed = 750f;

    private Camera _camera;
    private IInputService _inputService;

    private void Awake()
    {
      _inputService = Game.InputService;
    }

    private void Start()
    {
      _camera = Camera.main;
      _camera?.GetComponent<CameraFollow>().SetTarget(gameObject);
    }

    private void Update()
    {
      Rotate();
      Move();
    }

    private void Rotate()
    {
      Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
      Plane plane = new Plane(Vector3.up, Vector3.zero);
      if (plane.Raycast(ray, out float distance))
      {
        Vector3 worldPosition = ray.GetPoint(distance);
        
        Vector3 direction = (worldPosition - transform.position);
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.001f)
        {
          Quaternion targetRotation = Quaternion.LookRotation(direction);
          
          transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation, 
            _rotationSpeed * Time.deltaTime
          );
        }
      }
    }

    private void Move()
    {
      var movementDirection = new Vector3(_inputService.Axis.x, 0, _inputService.Axis.y).normalized;
      transform.position += movementDirection * (_movementSpeed * Time.deltaTime);
    }
  }
}