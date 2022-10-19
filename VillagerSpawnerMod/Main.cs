using MelonLoader;
using System;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VillagerSpawnerMod.UI;

namespace VillagerSpawnerMod
{
    public static class BuildInfo
    {
        public const string Name = "VillagerSpawnerMod";
        public const string Description = "Mod to spawn villager"; 
        public const string Author = "donimuzur"; // Author of the Mod.  (MUST BE SET)
        public const string Company = "donimuzur@gmail.com"; // Company that made the Mod.  (Set as null if none)
        public const string Version = "2.2.3"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class VillagerSpawnerMod : MelonMod
    {
        bool finished = false;
        public GameManager gameManager = null;
        public InputManager inputManager= null;
        public GameObject selectedBuilding = null;
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("VillagerSpawnerMod Started");
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            finished = false;
        }
        public override void OnUpdate()
        {
            if (finished) return;
            if (SceneManager.GetActiveScene().name != "Frontier") return;

            var gameManagerObj = GameObject.Find("GameManager");
            if(gameManagerObj != null )
            {
                inputManager = gameManagerObj.GetComponent<InputManager>();
                selectedBuilding = inputManager.selectedObject;
                if (selectedBuilding != null && selectedBuilding.tag == "TownCenter" && !finished)
                {
                    var getUIpausWindowList =  Resources.FindObjectsOfTypeAll(Il2CppType.From(typeof(UIPauseWindow)));

                    if(getUIpausWindowList != null && getUIpausWindowList.Count >0)
                    {
                        var getUIpausWindow = getUIpausWindowList[0].TryCast<UIPauseWindow>();
                        var getResumeButton = getUIpausWindow.gameObject.transform.FindChild("Pivot").FindChild("Main Panel").FindChild("Button_Resume");
                        if (getResumeButton != null )
                        {
                            var getUITownCenterOverview = GameObject.FindObjectOfType<UITownCenterOverview>();
                            if(getUITownCenterOverview != null)
                            {
                                Sprite btnSprite = getResumeButton.GetComponent<Image>().sprite;
                                GameObject uiButton = UIControls.CreateButton(new UIControls.Resources{standard = btnSprite});
                                uiButton.name = "AddVillagerButton";
                                GameObject gameObject3 = new GameObject("AddVillagerButtonIcon1");
                                var component31 = gameObject3.AddComponent<RectTransform>();

                                var component32 = gameObject3.AddComponent<Image>();
                                component32.sprite = GlobalAssets.uiAssetMap.villagerIcon;
                                component32.preserveAspect = true;
                                gameObject3.transform.SetParent(uiButton.transform, false);
                                
                                var buttonActionuiButton = uiButton.GetComponent<Button>();
                                buttonActionuiButton.onClick.AddListener(delegate ()
                                {
                                    var townCenterLoc = GameObject.FindObjectOfType<TownCenter>();
                                    var villagerPopulationManager = gameManagerObj.GetComponent<VillagerPopulationManager>();
                                    villagerPopulationManager.SpawnVillagerImmigration(townCenterLoc.transform.localPosition, true);

                                });
                                
                                GameObject gameObject2 = new GameObject("AddVillagerButtonIcon2");
                                var component21 = gameObject2.AddComponent<RectTransform>();

                                var component22 = gameObject2.AddComponent<Image>();
                                component22.sprite = GlobalAssets.uiAssetMap.chevronPositive;
                                component22.preserveAspect = true;
                                gameObject2.transform.SetParent(uiButton.transform, false);
                                
                                var component3 = uiButton.AddComponent<HorizontalLayoutGroup>();
                                component3.padding.top = 10;
                                component3.padding.bottom = 5;
                                component3.padding.left = 20;
                                component3.padding.right = 20;

                                var uiButtonlayoutElement = uiButton.AddComponent<LayoutElement>();
                                uiButtonlayoutElement.ignoreLayout = true;
                                
                                var uiButtonContentSizeFitter = uiButton.AddComponent<ContentSizeFitter>();
                                uiButtonlayoutElement.ignoreLayout = true;

                                uiButton.transform.SetParent(getUITownCenterOverview.gameObject.transform.FindChild("TownProgression").FindChild("TownCenterProgression").gameObject.transform, false);
                                var uiButtonRectTransofrm = uiButton.GetComponent<RectTransform>();
                                uiButtonRectTransofrm.sizeDelta = new Vector2(80, 35);
                                uiButtonRectTransofrm.localPosition = new Vector3(400, -71, 0);
                                finished = true;
                            }
                         
                        }
                    }
                }
            }
        }
    }
}
