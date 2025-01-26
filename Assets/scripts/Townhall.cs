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
        if (Input.GetMouseButtonDown(0) & this.gameObject.GetComponent<Building>().getMouseHovering() & this.gameObject.GetComponent<Building>().Placed)
        {
            Debug.Log($"Sé que has hecho click");
            UI.current.OpenMenu($"townhall");
            
        }
    }

    

}
