using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factories
{
  public interface IGameFactory : IService
  {
    GameObject CreatePlayer(Transform spawnPoint);
    void CreateHud();
  }
}