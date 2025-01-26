using UnityEngine;

public class simpleInventory : MonoBehaviour
{
    public static simpleInventory current;
    public int[] holding = new int[4] {10, 10, 10, 10};
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
}
