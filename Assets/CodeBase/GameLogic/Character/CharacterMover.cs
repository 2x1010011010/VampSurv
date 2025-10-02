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

    [SerializeField, BoxGroup("ANIMATION CONTROLLER")] private CharacterAnimator _animator;

    private Camera _camera;
    private IInputService _inputService;

    private void Awake()
    {
      _inputService = Game.InputService;
    }

    private void Start()
    {
      _camera = Camera.main;

      var cameraFollow = _camera?.GetComponent<CameraFollow>();
      if (cameraFollow == null) return;
      if (cameraFollow.Target == null)
        cameraFollow.SetTarget(gameObject);
    }

    private void Update()
    {
      Rotate();
      Move();
    }

    private void Rotate()
    {
      Vector3? lookAtPoint = _inputService.LookDirection;
      if (lookAtPoint == null)
        return;

      Vector3 direction = lookAtPoint.Value - transform.position;
      direction.y = 0f;

      if (direction.sqrMagnitude > _movementEpsilon)
      {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(
          transform.rotation,
          targetRotation,
          _rotationSpeed * Time.deltaTime
        );
      }
    }

    private void Move()
    {
      Vector3 movementDirection = new Vector3(_inputService.Axis.x, 0, _inputService.Axis.y).normalized;

      if (movementDirection.magnitude < _movementEpsilon)
      {
        _animator.SetDirection(Vector3.zero);
        return;
      }

      transform.position += movementDirection * (_movementSpeed * Time.deltaTime);

      Vector3 localDirection = transform.InverseTransformDirection(movementDirection).normalized;
      _animator.SetDirection(localDirection);
    }
  }
}