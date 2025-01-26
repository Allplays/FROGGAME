using UnityEngine;
using UnityEngine.Rendering;

public class ItemList : MonoBehaviour
{
    public Item itemPrefab;

    public static ItemList current;
    private Item temp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnItem(Item.ItemType tipo, Vector3 posicion)
    {
        temp = Instantiate(itemPrefab, posicion, Quaternion.identity);
    }

    public Item[] GetItems()
    {
        
        int num_items = this.gameObject.transform.childCount;
        Item[] items = new Item[num_items];
        for (int i = 0; i < num_items; i++)
        {
            items[i] = this.gameObject.transform.GetChild(i).gameObject.GetComponent<Item>();
        }
        return items;
    }
}
