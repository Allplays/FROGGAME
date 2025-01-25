using UnityEngine;

public class Townhall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static Townhall current;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) & Building.current.getMouseHovering() & Building.current.Placed)
        {
            Debug.Log($"Sé que has hecho click");
            UI.current.OpenMenu($"townhall");
            
        }
    }

    

}
