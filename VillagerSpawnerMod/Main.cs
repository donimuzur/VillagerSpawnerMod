using MelonLoader;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace VillagerSpawnerMod
{
    public static class BuildInfo
    {
        public const string Name = "VillagerSpawnerMod";
        public const string Description = "Mod to spawn villager"; 
        public const string Author = "donimuzur"; // Author of the Mod.  (MUST BE SET)
        public const string Company = "donimuzur@gmail.com"; // Company that made the Mod.  (Set as null if none)
        public const string Version = "2.2.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class VillagerSpawnerMod : MelonMod
    {
        private GameManager component = null;
        private GameObject obj = null;
        private GameObject buttonTemplate = null;
        public Action action;

        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Started");
        }
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                MelonLogger.Msg("V pressed");
                var gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

                if (gameManager != null)
                {
                    Vector3 mousePosition = Input.mousePosition;
                    Vector3 terrainWorldPointUnderScreenPoint = gameManager.terrainManager.GetTerrainWorldPointUnderScreenPoint(mousePosition);
                    
                    gameManager.villagerPopulationManager.SpawnVillagerImmigration(terrainWorldPointUnderScreenPoint, true);
                }
            }
            if (obj != null)
            {
                return;
            }
            var Button_Resume = GameObject.Find("Button_Resume");
            if (Button_Resume != null  )
            {
                buttonTemplate = GameObject.Instantiate(Button_Resume);
            }
            
            var getTowncenter = GameObject.Find("TownCenterProgression");
            if(getTowncenter != null)
            {
                MelonLogger.Msg("Creating UI AddVillagerButton on TownCenter");
                obj = getTowncenter;
            }
            if (obj != null && buttonTemplate != null)
            {
                buttonTemplate.transform.DetachChildren();
                buttonTemplate.name = "AddVillagerButton";

                var buttonAction = buttonTemplate.GetComponent<Button>();
                buttonAction.onClick.AddListener(addPopulation);

                RectTransform toDestroy1 = buttonTemplate.GetComponent<RectTransform>();
                GameObject.Destroy(toDestroy1);

                var toDestroy2 = buttonTemplate.GetComponent<LayoutElement>();
                GameObject.Destroy(toDestroy2);

                buttonTemplate.AddComponent<RectTransform>();
                
                var buttonTemplatelayoutElement = buttonTemplate.AddComponent<LayoutElement>();
                buttonTemplatelayoutElement.ignoreLayout = true;

                GameObject gameObject3 = new GameObject("AddVillagerButtonIcon1");
                var component31 = gameObject3.AddComponent<RectTransform>();

                var component32 = gameObject3.AddComponent<Image>();
                component32.sprite = GlobalAssets.uiAssetMap.villagerIcon;
                component32.preserveAspect = true;
                gameObject3.transform.SetParent(buttonTemplate.transform, false);

                GameObject gameObject2 = new GameObject("AddVillagerButtonIcon2");
                var component21 = gameObject2.AddComponent<RectTransform>();

                var component22 = gameObject2.AddComponent<Image>();
                component22.sprite = GlobalAssets.uiAssetMap.chevronPositive;
                component22.preserveAspect = true;
                gameObject2.transform.SetParent(buttonTemplate.transform, false);

                var component3 = buttonTemplate.AddComponent<HorizontalLayoutGroup>();
                component3.padding.top = 10;
                component3.padding.bottom = 5;
                component3.padding.left = 20;
                component3.padding.right = 20;
                
                var buttonTemplateRectTransofrm = buttonTemplate.GetComponent<RectTransform>();
                buttonTemplateRectTransofrm.sizeDelta =new  Vector2(80,35);

                buttonTemplate.transform.SetParent(obj.transform, false);
                buttonTemplate.transform.localPosition = new Vector3(400, -70, 0);

                buttonTemplate.SetActiveRecursively(true);
            }
        }
        void addPopulation()
        {
            component = GameObject.FindObjectOfType<GameManager>();
            if (component != null)
            {
                var townCenter = component.inputManager.selectedObject.GetComponent<Building>();
                if (townCenter != null ) {
                    var townCenterLoc = townCenter.transform.localPosition;
                    
                    component.villagerPopulationManager.SpawnVillagerImmigration(townCenterLoc,  true);                    
                }

            }
        }
    }
}
