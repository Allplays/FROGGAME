using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI current;

    private string menuUp = "noMenu";

    public GameObject buildingPrefab;

    public GameObject Grid;
    public GameObject MainTilemap;
    public GameObject TempTilemap;

    public Button buildButton;
    public Button unbuildButton;

    public GameObject[] Buttons;

    [SerializeField] public GameObject background; 
    [SerializeField] public GameObject marco;

    [SerializeField] public GameObject sprite;
    private Image titleRenderer;

    Dictionary<string, Dictionary<string, int[]>> MenuRecipes = new Dictionary<string, Dictionary<string, int[]>>();
    Dictionary<string, int[]> unlockableRecipes = new Dictionary<string, int[]>();

    private void Awake()
    {
        current = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        titleRenderer = sprite.GetComponent<Image>();
        background.SetActive(false);
        marco.SetActive(false);
        sprite.SetActive(false);

        ButtonsSwitch(false);

        buildButton.gameObject.SetActive(false);
        unbuildButton.gameObject.SetActive(false);

        Grid.SetActive(false);
        MainTilemap.SetActive(false);
        TempTilemap.SetActive(false);

        MenuRecipes["townhall"] = new Dictionary<string, int[]>
        {
            { "defense_tower", new int[] { 0, 0, 0, 3 } },
            { "house", new int[] { 0, 2, 2, 0} }
        };

        MenuRecipes["shrine"] = new Dictionary<string, int[]>
        {
            { "chimi", new int[] { 0, 0, 2, 0 } },
            { "lula", new int[] { 3, 0, 0, 0 } },
            { "poppy", new int[] { 0, 3, 0, 0 } },
            { "lennon", new int[] { 1, 0, 1, 0 } }
        };

        MenuRecipes["building"] = new Dictionary<string, int[]>
        {
            { "townhall", new int[] { 3, 0, 2, 0 } },
        };

        unlockableRecipes["tower_defense"] = new int[] { 5, 3, 0, 0 };
        unlockableRecipes["house"] = new int[] { 0, 5, 5, 0 };
    }

    // Update is called once per frame
    void Update()
    {
        //if (menuUp == "grid" & GridBuildingSystem.current.temp)
        //{

        //}
        if (Input.GetKeyUp(KeyCode.Escape) & menuUp != "noMenu")
        {
            CloseMenu();
        }
        else if (Input.GetKeyUp(KeyCode.B) & menuUp == "noMenu")
        {
            OpenMenu($"building");
        }
    }

    public void OpenMenu(string title)
    {
        menuUp = title;
        titleRenderer.sprite = Resources.Load<Sprite>($"titulo_" + title);
        background.SetActive(true);
        marco.SetActive(true);
        sprite.SetActive(true);

        ButtonsSwitch(true, MenuRecipes[menuUp].Keys.ToArray().Length);
    }

    public void CloseMenu()
    {
        menuUp = "noMenu";
        background.SetActive(false);
        marco.SetActive(false);
        sprite.SetActive(false);

        ButtonsSwitch(false);

        Grid.SetActive(false);
        MainTilemap.SetActive(false);
        TempTilemap.SetActive(false);
    }

    public void CheckCraft(int numero)
    {
        /*
        //Debug.Log(numero);
        string[] keys = MenuRecipes[menuUp].Keys.ToArray();
        if (numero > keys.Length)
        {
            //Debug.LogError("Ese botón tiene que estar desactivado");
            return;
        }
        for (int i = 0; i < MenuRecipes[menuUp][keys[numero-1]].Length; i++)
        {
            if (Inventory.current.holding[i] < MenuRecipes[menuUp][keys[numero - 1]][i])
            {
                //Debug.Log($"Te faltan materiales");
                //Debug.Log(i);
                //Debug.Log(Inventory.current.holding[i]);
                //Debug.Log(MenuRecipes[menuUp][keys[numero - 1]][i]);
                return;
            }
        }

        for (int i = 0; i < MenuRecipes[menuUp][keys[numero-1]].Length; i++)
        {
            Inventory.current.holding[i] -= MenuRecipes[menuUp][keys[numero-1]][i];
        }
        //Debug.Log(menuUp);
        switch (menuUp)
        {
            case "building":
                //Debug.Log("Estoy en building, todo correcto");
                CloseMenu();
                menuUp = "grid";
                Grid.SetActive(true);
                MainTilemap.SetActive(true);
                TempTilemap.SetActive(true);
                string[] buildingKeys = MenuRecipes["building"].Keys.ToArray();
                buildingPrefab = Resources.Load<GameObject>(buildingKeys[numero - 1]);
                GridBuildingSystem.current.InitializeWithBuilding(buildingPrefab);
                break;
            case "townhall":
                string[] unlockableKeys = unlockableRecipes.Keys.ToArray();
                MenuRecipes["building"][unlockableKeys[numero-1]] = unlockableRecipes[unlockableKeys[numero-1]];
                unlockableRecipes.Remove(unlockableKeys[numero-1]);
                MenuRecipes["townhall"].Remove(unlockableKeys[numero - 1]);
                CloseMenu();
                break;

        }
        */

    }

    private void ButtonsSwitch(bool mode, int numero = 6)
    {
        for (int i = 0; i < numero; i++)
        {
            Buttons[i].SetActive(mode);
        }
    }
}
