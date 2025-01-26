using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Item))]
public class ItemEditor : Editor
{
    void OnEnable()
    {
        // Refresh the sprite preview when the editor is loaded
        Item item = (Item)target;
        UpdateSpritePreview(item);
    }

    public override void OnInspectorGUI()
    {
        Item item = (Item)target;

        // Draw the default inspector with the header and the itemType selector
        DrawDefaultInspector();

        // Update sprite based on the selected ItemType
        UpdateSpritePreview(item);

        // Optionally, force the editor to redraw the GUI
        Repaint();
    }

    private void UpdateSpritePreview(Item item)
    {
        // Use the method to get the spriteRenderer
        SpriteRenderer spriteRenderer = item.GetSpriteRenderer();

        // Check if the spriteRenderer is null to avoid errors
        if (spriteRenderer == null)
        {
            spriteRenderer = item.GetComponent<SpriteRenderer>();
        }

        // Update the sprite preview in the editor based on the itemType
        switch (item.itemType)
        {
            case Item.ItemType.Piedra:
                spriteRenderer.sprite = item.piedraSprite;
                break;
            case Item.ItemType.Palo:
                spriteRenderer.sprite = item.paloSprite;
                break;
            case Item.ItemType.Savia:
                spriteRenderer.sprite = item.saviaSprite;
                break;
            default:
                spriteRenderer.sprite = null;
                break;
        }
    }
}