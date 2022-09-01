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
        bool finished = false;
        GameManager gameManager = null;
        GameObject gameManagerObject = null;
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("VillagerSpawnerMod Started");
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            finished = false;
            MelonLogger.Msg("Re-creating Add Villager Button");
        }
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
               
                gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

                if (gameManager != null)
                {
                    Vector3 mousePosition = Input.mousePosition;
                    Vector3 terrainWorldPointUnderScreenPoint = gameManager.terrainManager.GetTerrainWorldPointUnderScreenPoint(mousePosition);

                    gameManager.villagerPopulationManager.SpawnVillagerImmigration(terrainWorldPointUnderScreenPoint, true);
                }
            }

            gameManagerObject = GameObject.Find("GameManager");
            if (gameManagerObject == null) return;

            if (finished) return;

            MelonLogger.Msg("Creating UI");
            var getUIpausWindow = GameObject.FindObjectsOfType<UIPauseWindow>();
            foreach(UIPauseWindow uipausWindow in getUIpausWindow)
            {
                var getResumButton = uipausWindow.gameObject.transform.FindChild("Pivot").FindChild("Main Panel").FindChild("Button_Resume");
                if(getResumButton != null)
                {
                    var getTownCenterUIlist = GameObject.FindObjectsOfTypeAll(Il2CppType.From(typeof(UITownCenterOverview)));
                    var idx = 1;
                    foreach(var townCenterUI in getTownCenterUIlist)
                    {
                        var getTownCenterUI =  townCenterUI.TryCast<UITownCenterOverview>().gameObject.transform.FindChild("TownProgression").FindChild("TownCenterProgression").gameObject;
                        if (getTownCenterUI != null)
                        {
                            var createdButton = createUI(getTownCenterUI.gameObject, getResumButton.gameObject, idx);
                            createdButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(860 ,- 170);

                            createdButton.transform.SetParent(getTownCenterUI.transform, false);

                            createdButton.SetActiveRecursively(true);
                            idx++;
                        }
                    }
                }
            }
            finished = true;
        }
        GameObject createUI(GameObject obj, GameObject button, int idx)
        {
            var createNewButton = GameObject.Instantiate(button);
            createNewButton.transform.DetachChildren();
            createNewButton.name = "AddVillagerButton"+idx;

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
            return createNewButton;
        }
        void addPopulation()
        {
            var addPopulationGameManagerObject = GameObject.Find("GameManager");
            if (addPopulationGameManagerObject != null)
            {
                var addPopulationGameManager = addPopulationGameManagerObject.GetComponent<InputManager>();
                {
                    if(addPopulationGameManager != null)
                    {
                        var townCenter = addPopulationGameManager.selectedObject.GetComponent<TownCenter>();
                        if (townCenter != null)
                        {
                            var townCenterLoc = townCenter.transform.localPosition;
                            var villagerPopulationManager = addPopulationGameManagerObject.GetComponent<VillagerPopulationManager>();
                            villagerPopulationManager.SpawnVillagerImmigration(townCenterLoc, true);
                        }
                    }
                }
            }
        }
    }
}
