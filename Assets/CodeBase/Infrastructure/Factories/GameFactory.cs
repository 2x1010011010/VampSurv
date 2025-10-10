using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
  public class GameFactory : IGameFactory
  {
    private readonly IAssetProvider _assets;
    
    public GameFactory(IAssetProvider assets)
    {
      _assets = assets;
    }
    
    public GameObject CreatePlayer(Transform spawnPoint) => 
      _assets.Instantiate(AssetPaths.CharacterPath, at: spawnPoint);

    public void CreateHud() => 
      _assets.Instantiate(AssetPaths.HUD);
  }
}