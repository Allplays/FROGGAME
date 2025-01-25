using UnityEngine;
using UnityEngine.Rendering;

public class Inventory : MonoBehaviour
{
    public Vector4 holding = new Vector4 (100,100,100,100);

    public static Inventory current;
    private void Awake()
    {
        current = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
