using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public bool Placed = false;
    public bool mouseHovering;
    public BoundsInt area;
    public Color hoveringColor;
    private Color originalColor;
    [SerializeField] public GameObject sprite;
    private SpriteRenderer spriteRenderer;
    public static Building current;

    void Start()
    {
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void Awake()
    {
        current = this;
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
    }

    #endregion
    void Update()
    {

    }

    private void OnMouseOver()
    {
        mouseHovering = true;
        if (Placed)
        {
            //Debug.Log($"El raton ha pasado");
            
            spriteRenderer.color = hoveringColor;
        }
    }

    private void OnMouseExit()
    {
        mouseHovering = false;
        if (Placed)
        {
            spriteRenderer.color = originalColor;
        }
    }

    public bool getMouseHovering()
    {
        return mouseHovering;
    }

    public void Disappear()
    {
        Vector3Int positionInt = GridBuildingSystem.current.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;
        GridBuildingSystem.current.UntakeArea(areaTemp);
        UI.current.CloseMenu();
        //canvas.ac
        //placeButton.gameObject
        //disappearButton.gameObject
        //sprite
        //current
    }
}
