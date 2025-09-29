using CodeBase.Infrastructure.Services.InputService;

namespace CodeBase.Infrastructure
{
  public sealed class Game
  {
    public static IInputService InputService;
    
    public Game() => 
      InputService = new DesktopInputService();
  }
}