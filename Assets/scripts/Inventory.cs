using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField] private float pickupRadius = 1f;

    private Dictionary<string, int> inventory = new Dictionary<string, int>(); 

    void Start()
    {
        
        inventory["CacaLennon"] = 0;
        inventory["Palo"] = 0;
        inventory["sap"] = 0;
        inventory["stone"] = 0;
    }

    void Update()
    {
        DetectAndPickupObjects();
    }

    private void DetectAndPickupObjects()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, pickupRadius);

        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider != null && hitCollider.gameObject != null)
            {
                string objectTag = hitCollider.tag; 

                
                if (inventory.ContainsKey(objectTag))
                {
                    Destroy(hitCollider.gameObject); 
                    inventory[objectTag]++; 
                    Debug.Log($"{objectTag} collected! Total: {inventory[objectTag]}");
                }
            }
        }
    }

    public int GetItemCount(string itemTag)
    {
        
        return inventory.ContainsKey(itemTag) ? inventory[itemTag] : 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}
