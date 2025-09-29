using CodeBase.Infrastructure.Services.InputService;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public sealed class Bootstrapper : MonoBehaviour
  {
    private Game _game;

    private void Awake()
    {
      _game = new Game();
      DontDestroyOnLoad(this);
    }
  }
}