using UnityEngine;

public class Inventory : MonoBehaviour
{
    public float pickupRadius = 3f;
    public InventoryManager inventoryManager;

    void Update()
    {
        DetectNearbyItems();
    }

    private void DetectNearbyItems()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pickupRadius);

        foreach (var collider in colliders)
        {
            Item item = collider.GetComponent<Item>();
            if (item != null)
            {
                PickUpItem(item);
            }
        }
    }

    private void PickUpItem(Item item)
    {
        if (inventoryManager.AddItem(item.itemType, 1))
        {
            Debug.Log($"Picked up {item.itemType}");
            item.PickUp();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}