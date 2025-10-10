using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
  public class GameFactory : IGameFactory
  {
    public GameObject CreatePlayer(Transform spawnPoint)
    {
      return Instantiate(Constants.CharacterPath, at: spawnPoint);
    }

    public void CreateHud()
    {
      Instantiate(Constants.HUD);
    }

    private static GameObject Instantiate(string path)
    {
      var prefab = Resources.Load<GameObject>(path);
      return Object.Instantiate(prefab);
    }

    private static GameObject Instantiate(string path, Transform at)
    {
      var prefab = Resources.Load<GameObject>(path);
      return Object.Instantiate(prefab, at);
    }
  }
}