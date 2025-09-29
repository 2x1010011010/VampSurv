using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.GameLogic.CameraLogic
{
  public class CameraFollow : MonoBehaviour
  {
    [SerializeField, BoxGroup("CAMERA SETUP")] private Vector3 _offset;
    [SerializeField, BoxGroup("CAMERA SETUP")] private Transform _targetTransform;

    public void SetTarget(GameObject target)
    {
      _targetTransform = target.transform;
      
    }

    private void LateUpdate()
    {
      if (_targetTransform == null) return;
      
      transform.position = _targetTransform.position + _offset;
    }
  }
}