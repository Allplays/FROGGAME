using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class GridBuildingSystem : MonoBehaviour
{
    public static GridBuildingSystem current;

    public GridLayout gridLayout;
    public Tilemap MainTilemap;
    public Tilemap TempTilemap;

    private static Dictionary<TileType, TileBase> tileBases = new Dictionary<TileType, TileBase>();

    private Building temp;
    private Vector3 prevPos;
    private BoundsInt prevArea;

    #region Unity Methods

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        tileBases.Add(TileType.White, Resources.Load<TileBase>("white"));
        tileBases.Add(TileType.Green, Resources.Load<TileBase>("green"));
        tileBases.Add(TileType.Red, Resources.Load<TileBase>("red"));
        tileBases.Add(TileType.Empty, Resources.Load<TileBase>("blue"));
    }

    private void Update()
    {
        
        if (!temp)
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(0))
        {   
            
            if (EventSystem.current.IsPointerOverGameObject(0))
            {
                return;
            }
            if (!temp.Placed)
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int cellPos = gridLayout.LocalToCell(touchPos);
                //Debug.LogError(prevPos);
                //Debug.LogError(cellPos);
                if (prevPos != cellPos)
                {
                    //Debug.LogError($"Pitolingo");
                    temp.transform.localPosition = gridLayout.CellToLocalInterpolated(cellPos + new Vector3(.5f, .5f, 0f));
                    prevPos = cellPos;
                    FollowBuilding();
                }
            }
        }
        
    }

    #endregion

    #region Tilemap management

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        //Debug.Log(array.Length);
        int counter = 0;

        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            //Debug.Log(pos);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }
        return array;
    }

    private static void SetTilesBlock(BoundsInt area, TileType type, Tilemap tilemap)
    {
        int size = area.size.x * area.size.y * area.size.z;
        TileBase[] tileArray = new TileBase[size];
        FillTiles(tileArray, type);
        tilemap.SetTilesBlock(area, tileArray);
    }

    private static void FillTiles(TileBase[] arr, TileType type)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = tileBases[type];
            //Debug.Log(arr[i]);
        }
    }

    #endregion

    #region Building Placement

    public void InitializeWithBuilding(GameObject building)
    {
        temp = Instantiate(building, Vector3.zero, Quaternion.identity).GetComponent<Building>();
        FollowBuilding();
    }

    private void ClearArea()
    {
        TileBase[] toClear = new TileBase[prevArea.size.x * prevArea.size.y * prevArea.size.z];
        FillTiles(toClear, TileType.Empty);
        TempTilemap.SetTilesBlock(prevArea, toClear);
    }

    private void FollowBuilding()
    {
        ClearArea();

        temp.area.position = gridLayout.WorldToCell(temp.gameObject.transform.position);
        BoundsInt buildingArea = temp.area;

        TileBase[] baseArray = GetTilesBlock(buildingArea, MainTilemap);

        int size = baseArray.Length;
        TileBase[] tileArray = new TileBase[size];

        for (int i = 0; i < baseArray.Length; i++)
        {   
            if (baseArray[i] == null)
            {
                FillTiles(tileArray, TileType.Red);
                break;
            }

            Tile tile1 = baseArray[i] as Tile;
            Tile tile2 = tileBases[TileType.White] as Tile;
            Debug.Log(tile1.color);
            Debug.Log(tile2.color);

            if (tile1.color == tile2.color)
            {
                tileArray[i] = tileBases[TileType.Green];
            }
            else
            {
                FillTiles(tileArray, TileType.Red);
                break;
            }
        }

        TempTilemap.SetTilesBlock(buildingArea, tileArray);
        prevArea = buildingArea;
    }

    public bool CanTakeArea(BoundsInt area)
    {
        TileBase[] baseArray = GetTilesBlock(area, MainTilemap);
        
        Tile tile2 = tileBases[TileType.White] as Tile;
        foreach (var b in baseArray)
        {
            Tile tile1 = b as Tile;
            if (tile1.color != tile2.color)
            {
                return false;
            }
        }
        return true;    
    }

    public void TakeArea(BoundsInt area)
    {
        Debug.Log($"Entro en la funcion");
        SetTilesBlock(area, TileType.Empty, TempTilemap);
        SetTilesBlock(area, TileType.Green, MainTilemap);
    }

    #endregion
}

public enum TileType
{
    Empty,
    White,
    Green,
    Red
}
