using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{
    private Dictionary<Item.ItemType, int> itemCounts = new Dictionary<Item.ItemType, int>();

    public bool AddItem(Item.ItemType itemType, int quantity)
    {
        if (quantity <= 0)
        {
            Debug.LogWarning("Cannot add zero or negative quantity.");
            return false;
        }

        if (!itemCounts.ContainsKey(itemType))
        {
            itemCounts[itemType] = 0;
        }

        itemCounts[itemType] += quantity;
        Debug.Log($"Added {quantity} of {itemType}. Current count: {itemCounts[itemType]}");
        return true;
    }

    public bool RemoveItem(Item.ItemType itemType, int quantity)
    {
        if (quantity <= 0)
        {
            Debug.LogWarning("Cannot remove zero or negative quantity.");
            return false;
        }

        if (itemCounts.ContainsKey(itemType) && itemCounts[itemType] >= quantity)
        {
            itemCounts[itemType] -= quantity;
            Debug.Log($"Removed {quantity} of {itemType}. Current count: {itemCounts[itemType]}");
            return true;
        }
        else
        {
            Debug.LogWarning($"Not enough of item {itemType} to remove {quantity}. Current count: {itemCounts.GetValueOrDefault(itemType, 0)}");
            return false;
        }
    }

    public int GetItemCount(Item.ItemType itemType)
    {
        return itemCounts.ContainsKey(itemType) ? itemCounts[itemType] : 0;
    }
}