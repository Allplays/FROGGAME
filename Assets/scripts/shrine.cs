using UnityEngine;

public class shrine : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) & this.gameObject.GetComponent<Building>().getMouseHovering() & UI.current.menuUp == "noMenu") 
        {
            Debug.Log($"Has clickado el shrine");
            UI.current.OpenMenu($"shrine");
            audioManager.PlayGeneralSfx(audioManager.InventorySfx);
        }
    }
}
