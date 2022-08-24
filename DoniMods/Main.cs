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
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
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
                    //gameManager.villagerPopulationManager.UpdatePopulation();
                }
            }
            if (obj != null)
            {
                return;
            }
            var Button_Resume = GameObject.Find("Button_Resume");
            if (Button_Resume != null && buttonTemplate == null )
            {
                buttonTemplate = GameObject.Instantiate(Button_Resume);
            }
           
            obj = GameObject.Find("TownCenterProgression");
            if (obj != null && buttonTemplate != null)
            {
                GameObject parent = null;
                GameObject parent2 = null;
                GameObject AddButton = new GameObject("NewButton");
                var a = obj.transform.GetChildCount();
                for (var idx = 0; idx < a; idx++)
                {
                    var s = obj.transform.GetChild(idx).gameObject;
                    for(var idxChild2 =0;idxChild2 < s.transform.GetChildCount(); idxChild2++)
                    {
                        var schild2 = s.transform.GetChild(idxChild2);
                        
                        if (schild2.name == "LeftArea")
                        {
                            var schild3 = schild2.transform.GetChild( 1);
                            parent = schild3.gameObject;
                            schild3 = schild2.transform.GetChild(schild2.GetChildCount() - 1);
                            parent2 = schild2.transform.GetChild(schild2.GetChildCount() - 1).gameObject;
                        }
                    }
                }

                #region[Add a Button]
                var toogle = parent2.transform.GetChild(0).gameObject;
                if(toogle != null )
                {
                    MelonLogger.Msg("Creating UI");
                    var buttonToClone = toogle.transform.GetChild(toogle.transform.GetChildCount() -1).gameObject.MemberwiseClone().Cast<GameObject>();
                    var buttonAddItem= GameObject.Instantiate(buttonToClone);

                    if (buttonAddItem != null)
                    {
                        buttonTemplate.transform.DetachChildren();
                        buttonTemplate.name = "AddItemButton";
                        buttonTemplate.transform.SetParent(parent2.transform, false);

                        RectTransform rectTransform = buttonTemplate.GetComponent<RectTransform>();
                        rectTransform.sizeDelta = new Vector2(100,40);
                        rectTransform.localPosition = new Vector3(550, 30, 0);

                        Button defaultColorTransitionValues = buttonTemplate.GetComponent<Button>();
                        defaultColorTransitionValues.onClick.AddListener(addPopulation);
                        ColorBlock colors = defaultColorTransitionValues.colors;
                        colors.highlightedColor = Color.blue;
                        colors.pressedColor = new Color(0.698f, 0.698f, 0.698f);
                        colors.disabledColor = new Color(0.521f, 0.521f, 0.521f);
          
                        GameObject gameObject3 = new GameObject("AddItemButtonIcon1");
                        var component31 = gameObject3.AddComponent<RectTransform>();
                        component31.anchorMin = Vector2.zero;
                        component31.anchorMax = Vector2.one;
                        component31.sizeDelta = Vector2.zero;
                        var component32 = gameObject3.AddComponent<Image>();
                        component32.sprite = GlobalAssets.uiAssetMap.villagerIcon;
                        component32.preserveAspect = true;
                        gameObject3.transform.SetParent(buttonTemplate.transform, false);

                        GameObject gameObject2 = new GameObject("AddItemButtonIcon2");
                        
                        var component1 =  gameObject2.AddComponent<RectTransform>();
                        component1.anchorMin = Vector2.zero;
                        component1.anchorMax = Vector2.one;
                        component1.sizeDelta = Vector2.zero;

                        var component2 = gameObject2.AddComponent<Image>();
                        component2.sprite = GlobalAssets.uiAssetMap.chevronPositive;
                        component2.preserveAspect = true;
                        gameObject2.transform.SetParent(buttonTemplate.transform, false);

                        var component3 = buttonTemplate.AddComponent<HorizontalLayoutGroup>();
                        component3.padding.top = 10;
                        component3.padding.bottom = 5;
                        component3.padding.left = 5;
                        component3.padding.right = 20;
                        component3.childForceExpandHeight = true;
                        component3.childForceExpandWidth = true;

                        buttonTemplate.transform.SetParent(parent2.transform, false);
                        buttonTemplate.SetActiveRecursively(true);
                    }
                }                
                #endregion
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
