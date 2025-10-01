using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.GameLogic.Character
{
  public class CharacterAnimator : MonoBehaviour
  {
    [SerializeField, BoxGroup("ANIMATOR SETUP")] private Animator _animator;
    
    private const string VerticalMove = "verticalMove";
    private const string HorizontalMove = "horizontalMove";

    private static readonly int Vertical = Animator.StringToHash(VerticalMove);
    private static readonly int Horizontal = Animator.StringToHash(HorizontalMove);

    public void SetDirection(Vector3 direction)
    {
      _animator.SetFloat(Vertical, direction.z);
      _animator.SetFloat(Horizontal, direction.x);
    }
  }
}