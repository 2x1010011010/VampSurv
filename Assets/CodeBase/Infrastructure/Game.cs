using CodeBase.Infrastructure.Services.InputService;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public sealed class Game
  {
    public static IInputService InputService;

    public Game()
    {
      if(Application.isMobilePlatform)
        InputService = new MobileInputService();
      else
        InputService = new DesktopInputService();
    }
  }
}