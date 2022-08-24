using MelonLoader;
using UnityEngine;

namespace VillagerSpawnerMod
{
    public static class BuildInfo
    {
        public const string Name = "VillagerSpawnerMod";
        public const string Description = "Mod to spawn villager"; 
        public const string Author = "donimuzur"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class VillagerSpawnerMod : MelonMod
    {

        public override void OnUpdate()
        {            
            if (Input.GetKeyDown(KeyCode.V))
            {
                var component= GameObject.Find("GameManager").GetComponent<GameManager>();

                if (component != null)
                {
                    Vector3 mousePosition = Input.mousePosition;
                    Vector3 terrainWorldPointUnderScreenPoint = component.terrainManager.GetTerrainWorldPointUnderScreenPoint(mousePosition);
                    component.villagerPopulationManager.SpawnVillager(terrainWorldPointUnderScreenPoint, Villager.JoinReason.Immigration, true);
                    component.villagerPopulationManager.UpdatePopulation();                     
                }
            }
            
        }

    }
}
