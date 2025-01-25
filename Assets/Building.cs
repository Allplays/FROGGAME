using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public bool Placed = false;
    public BoundsInt area;
    public Button button;

    void Start()
    {
        button.onClick.AddListener(CanBePlaced);
    }

    #region Build Methods

    public void CanBePlaced()
    {
        Vector3Int positionInt = GridBuildingSystem.current.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;
        //Debug.Log(GridBuildingSystem.current.CanTakeArea(areaTemp));
        if (GridBuildingSystem.current.CanTakeArea(areaTemp))
        {
            Place();
            return ;
        }
        return ;
    }

    public void Place()
    {
        Vector3Int positionInt = GridBuildingSystem.current.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;
        Placed = true;
        GridBuildingSystem.current.TakeArea(areaTemp);
        button.onClick.RemoveListener(CanBePlaced);
        Destroy(button.gameObject);
    }

    #endregion
    void Update()
    {
        
    }
}
