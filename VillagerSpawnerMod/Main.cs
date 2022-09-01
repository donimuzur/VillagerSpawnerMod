using MelonLoader;
using System;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VillagerSpawnerMod
{
    public static class BuildInfo
    {
        public const string Name = "VillagerSpawnerMod";
        public const string Description = "Mod to spawn villager"; 
        public const string Author = "donimuzur"; // Author of the Mod.  (MUST BE SET)
        public const string Company = "donimuzur@gmail.com"; // Company that made the Mod.  (Set as null if none)
        public const string Version = "2.2.2"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class VillagerSpawnerMod : MelonMod
    {
        public Action action;
        bool isFinishedCreateUI = false;
        GameManager gameManager = null;
        GameObject gameManagerObject = null;
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("VillagerSpawnerMod Started");
        }
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
               
                var gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

                if (gameManager != null)
                {
                    Vector3 mousePosition = Input.mousePosition;
                    Vector3 terrainWorldPointUnderScreenPoint = gameManager.terrainManager.GetTerrainWorldPointUnderScreenPoint(mousePosition);

                    gameManager.villagerPopulationManager.SpawnVillagerImmigration(terrainWorldPointUnderScreenPoint, true);
                }
            }

            var gameManagerObject = GameObject.Find("GameManager");
            if (gameManagerObject == null) return;

            var getUIButtonResume = GameObject.Find("Button_Resume");
            if (getUIButtonResume != null)
            {
                var getTownProgression = GameObject.Find("TownCenterProgression");
                if (getTownProgression != null)
                {
                    if (getTownProgression.transform.FindChild("AddVillagerButton") != null) return;
                    MelonLogger.Msg("Create UI Add Villager");
                    createUI(getTownProgression.gameObject, getUIButtonResume);
                }
            }
            
        }
        void createUI(GameObject obj, GameObject button)
        {
            var createNewButton = GameObject.Instantiate(button);
            createNewButton.transform.DetachChildren();
            createNewButton.name = "AddVillagerButton";

            //MelonLogger.Msg("AddVillagerButton");

            //var toDestroy1 = createNewButton.GetComponent<RectTransform>();
            //GameObject.Destroy(toDestroy1);

            var toDestroy2 = createNewButton.GetComponent<LayoutElement>();
            GameObject.Destroy(toDestroy2);

            //var toDestroy3 = createNewButton.GetComponent<UIPauseWindow>();
            //GameObject.Destroy(toDestroy3);

            //var toDestroy4 = createNewButton.GetComponent<Button>();
            //GameObject.Destroy(toDestroy4);

            //createNewButton.AddComponent<Button>();

            var buttonActioncreateNewButton = createNewButton.GetComponent<Button>();
            buttonActioncreateNewButton.onClick.AddListener(delegate
            {
                addPopulation();
            }
                );

            //createNewButton.AddComponent<RectTransform>();

            var createNewButtonlayoutElement = createNewButton.AddComponent<LayoutElement>();
            createNewButtonlayoutElement.ignoreLayout = true;

            //MelonLogger.Msg("AddVillagerButtonIcon1");
            GameObject gameObject3 = new GameObject("AddVillagerButtonIcon1");
            var component31 = gameObject3.AddComponent<RectTransform>();

            var component32 = gameObject3.AddComponent<Image>();
            component32.sprite = GlobalAssets.uiAssetMap.villagerIcon;
            component32.preserveAspect = true;
            gameObject3.transform.SetParent(createNewButton.transform, false);

            MelonLogger.Msg("AddVillagerButtonIcon2");
            GameObject gameObject2 = new GameObject("AddVillagerButtonIcon2");
            var component21 = gameObject2.AddComponent<RectTransform>();

            var component22 = gameObject2.AddComponent<Image>();
            component22.sprite = GlobalAssets.uiAssetMap.chevronPositive;
            component22.preserveAspect = true;
            gameObject2.transform.SetParent(createNewButton.transform, false);

            var component3 = createNewButton.AddComponent<HorizontalLayoutGroup>();
            component3.padding.top = 10;
            component3.padding.bottom = 5;
            component3.padding.left = 20;
            component3.padding.right = 20;

            var createNewButtonRectTransofrm = createNewButton.GetComponent<RectTransform>();
            createNewButtonRectTransofrm.sizeDelta = new Vector2(80, 35);

            createNewButton.transform.SetParent(obj.transform, false);
            createNewButton.SetActiveRecursively(true);
            createNewButton.transform.localPosition = new Vector3(400, -70, 0);
            
        }
        void addPopulation()
        {
            gameManagerObject = GameObject.Find("GameManager");
            if (gameManagerObject != null)
            {
                gameManager = gameManagerObject.GetComponent<GameManager>();
                {
                    if(gameManager != null)
                    {
                        var townCenter = gameManager.inputManager.selectedObject.GetComponent<TownCenter>();
                        if (townCenter != null)
                        {
                            var townCenterLoc = townCenter.transform.localPosition;

                            gameManager.villagerPopulationManager.SpawnVillagerImmigration(townCenterLoc, true);
                        }
                    }
                }
                

            }
        }
    }
}
