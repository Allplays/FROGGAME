using UnityEngine;

public class shrine : MonoBehaviour
{
    [SerializeField] AudioSource openShrineSfx;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) & this.gameObject.GetComponent<Building>().getMouseHovering())
        {
            Debug.Log($"Has clickado el shrine");
            UI.current.OpenMenu($"shrine");

            openShrineSfx.Play();
        }
    }
}
