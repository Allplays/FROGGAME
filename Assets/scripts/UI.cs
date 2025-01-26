using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    public static UI current;

    public string menuUp = "noMenu";

    public GameObject buildingPrefab;
    public GameObject frogPrefab;

    public GameObject panel;
    public GameObject panelBackground;

    public GameObject Grid;
    public GameObject MainTilemap;
    public GameObject TempTilemap;

    public GameObject[] Buttons;

    public GameObject ContinueButton;
    public GameObject ExitButton;

    [SerializeField] public GameObject background; 
    [SerializeField] public GameObject marco;

    [SerializeField] public GameObject sprite;
    private UnityEngine.UI.Image titleRenderer;

    public Dictionary<string, Dictionary<string, int[]>> MenuRecipes = new Dictionary<string, Dictionary<string, int[]>>();
    Dictionary<string, int[]> unlockableRecipes = new Dictionary<string, int[]>();

    int pipipopo;

    [SerializeField] AudioSource openMenuSfx;
    private void Awake()
    {
        current = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        titleRenderer = sprite.GetComponent<UnityEngine.UI.Image>();
        background.SetActive(false);
        marco.SetActive(false);
        sprite.SetActive(false);
           

        ButtonsSwitch(false);

        ContinueButton.SetActive(false);
        ExitButton.SetActive(false);
        panel.SetActive(false);
        panelBackground.SetActive(false);

        Grid.SetActive(false);
        MainTilemap.SetActive(false);
        TempTilemap.SetActive(false);

        MenuRecipes["townhall"] = new Dictionary<string, int[]>
        {
            { "turret", new int[] { 1, 0, 0, 3 } },
            { "house_1", new int[] { 0, 2, 2, 0} }
        };

        MenuRecipes["shrine"] = new Dictionary<string, int[]>
        {
            { "chimi_collect_2", new int[] { 0, 0, 2, 1 } },
            //{ "lula", new int[] { 3, 0, 0, 0 } },
            { "poppy_idle_1", new int[] { 0, 3, 0, 1 } },
            { "lennon_munch_1", new int[] { 1, 0, 1, 0 } }
        };

        MenuRecipes["building"] = new Dictionary<string, int[]>
        {
            { "townhall", new int[] { 3, 0, 2, 0 } },
        };

        unlockableRecipes["turret"] = new int[] { 5, 3, 0, 0 };
        unlockableRecipes["house_1"] = new int[] { 0, 5, 5, 0 };
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
            if (Building.current.Placed == false)
            {
                Building.current.Disappear();
            }
        }
        else if(Input.GetKeyUp(KeyCode.Escape) & menuUp == "noMenu")
        {
            menuUp = "pause";
            ContinueButton.SetActive(true);
            ExitButton.SetActive(true);
            panel.SetActive(true);
            panelBackground.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.B) & menuUp == "noMenu")
        {
            OpenMenu($"building");
            openMenuSfx.Play();
        }
    }

    public void OpenMenu(string title)
    {
        Time.timeScale = 0;
        Debug.Log("Pasamos a" + title);
        menuUp = title;
        titleRenderer.sprite = Resources.Load<Sprite>($"titulo_" + title);
        background.SetActive(true);
        marco.SetActive(true);
        sprite.SetActive(true);

        openMenuSfx.Play();
        Debug.Log(MenuRecipes[menuUp].Keys.ToArray().Length);
        ButtonsSwitch(true, MenuRecipes[menuUp].Keys.ToArray().Length, true);
    }

    public void CloseMenu()
    {
        Time.timeScale = 1;
        menuUp = "noMenu";
        //Debug.Log("Pasamos a noMenu");
        background.SetActive(false);
        marco.SetActive(false);
        sprite.SetActive(false);

        ButtonsSwitch(false);
        ContinueButton.SetActive(false);
        ExitButton.SetActive(false);
        panel.SetActive(false);
        panelBackground.SetActive(false);


        Grid.SetActive(false);
        MainTilemap.SetActive(false);
        TempTilemap.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CheckCraft(int numero)
    {
        
        //Debug.Log(numero);
        string[] keys = MenuRecipes[menuUp].Keys.ToArray();
        if (numero > keys.Length)
        {
            //Debug.LogError("Ese botón tiene que estar desactivado");
            return;
        }
        for (int i = 0; i < MenuRecipes[menuUp][keys[numero-1]].Length; i++)
        {
            //if (Inventory.current.holding[i] < MenuRecipes[menuUp][keys[numero - 1]][i])
            //{
                //Debug.Log($"Te faltan materiales");
                //Debug.Log(i);
                //Debug.Log(Inventory.current.holding[i]);
                //Debug.Log(MenuRecipes[menuUp][keys[numero - 1]][i]);
               //return;
            //}
        }

        for (int i = 0; i < MenuRecipes[menuUp][keys[numero-1]].Length; i++)
        {
            //Inventory.current.holding[i] -= MenuRecipes[menuUp][keys[numero-1]][i];
        }
        //Debug.Log(menuUp);
        switch (menuUp)
        {
            case "building":
                //Debug.Log("Estoy en building, todo correcto");
                CloseMenu();
                //Debug.Log("Pasamos a grid");
                menuUp = "grid";
                Grid.SetActive(true);
                MainTilemap.SetActive(true);
                TempTilemap.SetActive(true);
                string[] buildingKeys = MenuRecipes["building"].Keys.ToArray();
                //Debug.Log(buildingKeys[numero - 1]);
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
            case "shrine":
                string[] frogKeys = MenuRecipes["shrine"].Keys.ToArray();
                frogPrefab = Resources.Load<GameObject>(frogKeys[numero - 1]);
                Instantiate(frogPrefab, Vector3.zero, Quaternion.identity);
                CloseMenu();
                break;
        }
        

    }

    private void ButtonsSwitch(bool mode, int numero = 6, bool image = false)
    {
        for (int i = 0; i < numero; i++)
        {
            Buttons[i].SetActive(mode);
            if (image)
            {
                string[] keys = MenuRecipes[menuUp].Keys.ToArray();
                int[] positions = new int[2];
                pipipopo = 0;
                for (int j = 0; j < MenuRecipes[menuUp][keys[i]].Length; j++)
                //foreach (var e in MenuRecipes[menuUp][keys[i-1]])
                {
                    //Debug.Log(i);
                    //Debug.Log(j);
                    //Debug.Log(keys.Length);
                    //Debug.Log(keys[i]);
                    //Debug.Log(j);
                    //Debug.Log(MenuRecipes[menuUp][keys[i]][j]);
                    if (MenuRecipes[menuUp][keys[i]][j] != 0)
                    {
                        //Debug.Log("mamaguevo");
                        //Debug.Log(j);
                        //Debug.Log(pipipopo);
                        positions[pipipopo] = j;
                        pipipopo++;
                    }
                }
                //Debug.Log(positions[0].ToString());
                //Debug.Log(positions[1].ToString());
                //Debug.Log(keys[i]);
                Buttons[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(positions[1].ToString());
                Buttons[i].transform.GetChild(2).GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(positions[0].ToString());
                Buttons[i].transform.GetChild(3).GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("num" + MenuRecipes[menuUp][keys[i]][positions[0]].ToString());
                Buttons[i].transform.GetChild(1).GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("num" + MenuRecipes[menuUp][keys[i]][positions[1]].ToString());
                Buttons[i].transform.GetChild(4).GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(keys[i]);
            }
        }
    }
}
