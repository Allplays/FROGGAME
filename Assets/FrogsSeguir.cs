/*using UnityEngine;
using System.Collections;

public class FrogsSeguir : MonoBehaviour
{
    [SerializeField] private GameObject animeGirl; // Referencia al objeto Anime Girl
    [SerializeField] private FrogsChain frogChain; // Referencia al FrogChain de esta rana
    [SerializeField] private float followBackDistance = 2f; // Distancia a la que la rana debe estar para volver a unirse

    private bool isBeingDragged = false; // Si la rana está siendo arrastrada
    private Vector3 offset; // Offset para arrastrar correctamente
    private bool shouldReturnToChain = false; // Controla si la rana debería regresar a la cadena

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPosition();
        isBeingDragged = true;
        frogChain.enabled = false; // Detener el seguimiento mientras se arrastra
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        isBeingDragged = false;

       
    }

 

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}


*/