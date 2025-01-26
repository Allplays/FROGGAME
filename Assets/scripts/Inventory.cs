using UnityEngine;

public class Inventory : MonoBehaviour
{
    public float pickUpRadius = 3f;
    public InventoryManager inventoryManager;

    void Update()
    {
        DetectNearbyItems();
    }

    private void DetectNearbyItems()
    {
        // Shitty ass method iterates over all items
        // Could not get the collisions to behave properly :/

        Item[] items = FindObjectsOfType<Item>();

        foreach (var item in items)
        {
            float distance = Vector3.Distance(transform.position, item.transform.position);

            if (distance <= pickUpRadius)
            {
                item.PickUp();
                Debug.Log($"Item {item.itemType} is within range at a distance of {distance} meters.");
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
        Gizmos.DrawWireSphere(transform.position, pickUpRadius);
    }
}
