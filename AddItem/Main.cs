using MelonLoader;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddItemMod
{

    public static class BuildInfo
    {
        public const string Name = "AddItemMod";
        public const string Description = "Mod to Add Item";
        public const string Author = "donimuzur"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "2.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)    
    }

    public class AddItemMod : MelonMod
    {
        private static GameManager gameManager = null;
        private static GameObject obj = null;
        private static GameObject canvas = null;
        private static Item item = null;
        private static List<Item> items= null;
        private static GameObject buttonTemplate = null;
        private static Building selectedBuilding = null;
        private static ItemBundle itemBundle = null;
        private int counter = 0;
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("AddItemMod Started");
        }
        public override void OnUpdate()
        {
            var listItems = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(assembly => assembly.GetTypes())
                       .Where(type => type.IsSubclassOf(typeof(Item)));

            if (Input.GetKeyUp(KeyCode.RightControl) && Input.GetKeyUp(KeyCode.Alpha6))
            {
                var component = GameObject.Find("GameManager").GetComponent<GameManager>();
                if (component != null)
                {
                    var getBuilding = component.inputManager.selectedObject.GetComponent<Building>();
                    if (getBuilding != null)
                    {
                        ItemBundle itemBundle = new ItemBundle(new ItemBread(), 100, 100);
                        getBuilding.storage.AddItems(itemBundle);
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.RightControl) && Input.GetKeyUp(KeyCode.Alpha7))
            {
                var component = GameObject.Find("GameManager").GetComponent<GameManager>();
                if (component != null)
                {
                    var getBuilding = component.debugManager.inputManager.selectedObject.GetComponent<Building>();
                    if (getBuilding != null)
                    {
                        ItemBundle itemBundle = new ItemBundle(new ItemMeat(), 100, 100);
                        getBuilding.storage.AddItems(itemBundle);
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.RightControl) && Input.GetKeyUp(KeyCode.Alpha8))
            {
                var component = GameObject.Find("GameManager").GetComponent<GameManager>();
                if (component != null)
                {
                    var getBuilding = component.debugManager.inputManager.selectedObject.GetComponent<Building>();
                    if (getBuilding != null)
                    {
                        ItemBundle itemBundle = new ItemBundle(new ItemEggs(), 100, 100);
                        getBuilding.storage.AddItems(itemBundle);
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.RightControl) && Input.GetKeyUp(KeyCode.Alpha9))
            {
                var component = GameObject.Find("GameManager").GetComponent<GameManager>();
                if (component != null)
                {
                    var getBuilding = component.debugManager.inputManager.selectedObject.GetComponent<Building>();
                    if (getBuilding != null)
                    {
                        ItemBundle itemBundle = new ItemBundle(new ItemFruit(), 100, 100);
                        getBuilding.storage.AddItems(itemBundle);
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.RightControl) && Input.GetKeyUp(KeyCode.Alpha0))
            {
                var component = GameObject.Find("GameManager").GetComponent<GameManager>();
                if (component != null)
                {
                    var getBuilding = component.debugManager.inputManager.selectedObject.GetComponent<Building>();
                    if (getBuilding != null)
                    {
                        ItemBundle itemBundle = new ItemBundle(new ItemTool(), 100, 100);
                        getBuilding.storage.AddItems(itemBundle);
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.RightAlt) && Input.GetKeyUp(KeyCode.Alpha6))
            {
                var component = GameObject.Find("GameManager").GetComponent<GameManager>();
                if (component != null)
                {
                    var getBuilding = component.debugManager.inputManager.selectedObject.GetComponent<Building>();
                    if (getBuilding != null)
                    {
                        ItemBundle itemBundle = new ItemBundle(new ItemPlatemail(), 100, 100);
                        getBuilding.storage.AddItems(itemBundle);
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.RightAlt) && Input.GetKeyUp(KeyCode.Alpha7))
            {
                var component = GameObject.Find("GameManager").GetComponent<GameManager>();
                if (component != null)
                {
                    var getBuilding = component.debugManager.inputManager.selectedObject.GetComponent<Building>();
                    if (getBuilding != null)
                    {
                        ItemBundle itemBundle = new ItemBundle(new ItemShield(), 100, 100);
                        getBuilding.storage.AddItems(itemBundle);
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.RightAlt) && Input.GetKeyUp(KeyCode.Alpha8))
            {
                var component = GameObject.Find("GameManager").GetComponent<GameManager>();
                if (component != null)
                {
                    var getBuilding = component.debugManager.inputManager.selectedObject.GetComponent<Building>();
                    if (getBuilding != null)
                    {
                        ItemBundle itemBundle = new ItemBundle(new ItemHeavyWeapon(), 100, 100);
                        getBuilding.storage.AddItems(itemBundle);
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.RightAlt) && Input.GetKeyUp(KeyCode.Alpha9))
            {
                var component = GameObject.Find("GameManager").GetComponent<GameManager>();
                if (component != null)
                {
                    var getBuilding = component.debugManager.inputManager.selectedObject.GetComponent<Building>();
                    if (getBuilding != null)
                    {
                        ItemBundle itemBundle = new ItemBundle(new ItemCrossbow(), 100, 100);
                        getBuilding.storage.AddItems(itemBundle);
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.RightAlt) && Input.GetKeyUp(KeyCode.Alpha0))
            {
                var component = GameObject.Find("GameManager").GetComponent<GameManager>();
                if (component != null)
                {
                    var getBuilding = component.debugManager.inputManager.selectedObject.GetComponent<Building>();
                    if (getBuilding != null)
                    {
                        ItemBundle itemBundle = new ItemBundle(new ItemShoes(), 100, 100);
                        getBuilding.storage.AddItems(itemBundle);
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.RightAlt) && Input.GetKeyUp(KeyCode.M))
            {
                var component = GameObject.Find("GameManager").GetComponent<GameManager>();
                if (component != null)
                {
                    var getBuilding = component.debugManager.inputManager.selectedObject.GetComponent<Building>();
                    if (getBuilding != null)
                    {
                        ItemBundle itemBundle = new ItemBundle(new ItemGoldIngot(), 100, 100);
                        getBuilding.storage.AddItems(itemBundle);
                    }
                }
            }
            if (SceneManager.GetActiveScene().name != "Frontier")
            {
                return;
            }
            if (obj != null)
            {
                return;
            }
            var Button_Resume = GameObject.Find("Button_Resume");
            if (Button_Resume != null )
            {
                buttonTemplate = GameObject.Instantiate(Button_Resume);
            }
            if(canvas == null)
            {
                canvas = createUICanvas();
                createUIPanel(canvas);
                canvas.SetActiveRecursively(false);
            }
         
            
            var getUI = GameObject.FindObjectOfType<UIBuildingInfoWindow_New>();
            if( getUI != null)
            {
                obj = getUI.gameObject;
                
            }
            if (obj != null && buttonTemplate != null)
            {
                var child1 = obj.transform.GetChild(2);
                
                if(child1 != null)
                {
                    var child2 = obj.transform.GetChild(3);
                    var parent = child2.gameObject;
                    if(child2 != null)
                    {
                        #region buttonAddItem 
                        buttonTemplate.transform.DetachChildren();
                        buttonTemplate.name = "AddItemButton";
                        buttonTemplate.transform.SetParent(parent.transform, false);

                        RectTransform rectTransform = buttonTemplate.GetComponent<RectTransform>();
                        rectTransform.sizeDelta = new Vector2(0, 0);
                        rectTransform.localPosition = new Vector3(0, 0, 0);

                        Button defaultColorTransitionValues = buttonTemplate.GetComponent<Button>();
                        defaultColorTransitionValues.onClick.AddListener(openMainMenu);
                        ColorBlock colors = defaultColorTransitionValues.colors;
                        colors.highlightedColor = Color.blue;
                        colors.pressedColor = new Color(0.698f, 0.698f, 0.698f);
                        colors.disabledColor = new Color(0.521f, 0.521f, 0.521f);

                        GameObject gameObject3 = new GameObject("AddItemButtonIcon");
                        var component31 = gameObject3.AddComponent<RectTransform>();
                        rectTransform.sizeDelta = new Vector2(30,30);
                        component31.anchorMin = Vector2.zero;
                        component31.anchorMax = Vector2.one;
                        component31.sizeDelta = Vector2.zero;

                        GameObject gameObject4 = new GameObject("AddItemButtonText");
                        var component21 = gameObject4.AddComponent<RectTransform>();
                        component21.anchorMin = Vector2.zero;
                        component21.anchorMax = Vector2.one;
                        component21.sizeDelta = Vector2.zero;

                        var component22 = gameObject4.AddComponent<Text>();
                        component22.text = "Menu Item";
                        component22.fontSize = 14;
                        component22.fontStyle = FontStyle.Bold;
                        component22.color = Color.white;
                        component22.AssignDefaultFont();
                        component22.alignment = TextAnchor.MiddleCenter;
                        gameObject4.transform.SetParent(buttonTemplate.transform, false);

                        var component3 = buttonTemplate.AddComponent<GridLayoutGroup>();
                        component3.padding.top = 10;
                        component3.padding.bottom = 5;
                        component3.padding.left = 5;
                        component3.padding.right = 20;


                        buttonTemplate.transform.SetParent(parent.transform, false);
                        buttonTemplate.SetActiveRecursively(true);
                        #endregion
                    }
                }
                
            }
            
        }
        void openMainMenu()
        {
            canvas.SetActiveRecursively(true);
        }
        private void createUIPanel(GameObject parent)
        {
            
            GameObject AddItemMenuPanel = new GameObject("AddItemMenuPanel");
            AddItemMenuPanel.name = "AddItemMenuPanel";
            AddItemMenuPanel.transform.SetParent(parent.transform, false);
          
            RectTransform rectTransform = AddItemMenuPanel.AddComponent<RectTransform>();
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.sizeDelta = Vector2.zero;
            
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 500);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200);
            
            var uIDraggable = AddItemMenuPanel.AddComponent<UIDragable>();
            uIDraggable.rectTransformToDrag = rectTransform;

            Image image = AddItemMenuPanel.AddComponent<Image>();
            image.sprite = null;
            image.type = Image.Type.Sliced;
            image.color = new Color(0.2f, 0.2f, 0.2f, 0.392f);


            foreach (var item in items)
            {

            }
            AddItemMenuPanel.transform.SetParent(parent.transform, false);

        }
        public GameObject createUICanvas()
        {
            // Create a new Canvas Object with required components
            GameObject AddItemMenuCanvas = new GameObject("AddItemMenuCanvas");
            GameObject.DontDestroyOnLoad(AddItemMenuCanvas);

            Canvas canvas = new Canvas(AddItemMenuCanvas.AddComponent(UnhollowerRuntimeLib.Il2CppType.Of<Canvas>()).Pointer);

            canvas.renderMode = RenderMode.ScreenSpaceCamera;

            UnityEngine.UI.CanvasScaler cs = new UnityEngine.UI.CanvasScaler(AddItemMenuCanvas.AddComponent(UnhollowerRuntimeLib.Il2CppType.Of<UnityEngine.UI.CanvasScaler>()).Pointer);

            cs.screenMatchMode = UnityEngine.UI.CanvasScaler.ScreenMatchMode.Expand;
            cs.referencePixelsPerUnit = 100f;
            cs.referenceResolution = new Vector2(Screen.width, Screen.height);

            UnityEngine.UI.GraphicRaycaster gr = new UnityEngine.UI.GraphicRaycaster(AddItemMenuCanvas.AddComponent(UnhollowerRuntimeLib.Il2CppType.Of<UnityEngine.UI.GraphicRaycaster>()).Pointer);

            return AddItemMenuCanvas;
        }

        void addItem()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            selectedBuilding = gameManager.inputManager.selectedObject.GetComponent<Building>();
            if (selectedBuilding != null)
            {
                itemBundle = new ItemBundle(new ItemBread(), 100, 100);
                selectedBuilding.storage.AddItems(itemBundle);
            }
        }
    }

}

