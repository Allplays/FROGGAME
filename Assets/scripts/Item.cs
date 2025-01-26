using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Piedra,
        Palo,
        Savia
    }

    [Header("Item Settings")]
    public ItemType itemType;

    [Header("Sprites")]
    public Sprite piedraSprite;
    public Sprite paloSprite;
    public Sprite saviaSprite;

    public SpriteRenderer spriteRenderer;

    void Start()
    {
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is missing on the GameObject.");
            return;
        }
        switch (itemType)
        {
            case ItemType.Piedra:
                spriteRenderer.sprite = piedraSprite;
                break;
            case ItemType.Palo:
                spriteRenderer.sprite = paloSprite;
                break;
            case ItemType.Savia:
                spriteRenderer.sprite = saviaSprite;
                break;
            default:
                Debug.LogError($"Unknown ItemType: {itemType}");
                break;
        }
    }

    void Update()
    {
    }

    public void PickUp()
    {
        Debug.Log($"Picked up {itemType}!");
        Destroy(gameObject);
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }
}