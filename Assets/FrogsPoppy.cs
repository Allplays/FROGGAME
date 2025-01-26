using UnityEngine;

public class FrogsPoppy : MonoBehaviour
{
    [SerializeField] private GameObject animeGirl; // Referencia al objeto Anime Girl
                                                   // [SerializeField] private GameObject poopPrefab; // Prefab de la "caca"
    [SerializeField] private float speed = 2f; // Distancia a la que la rana debe estar para volver a unirse
    private float distanceBetween;  // Distancia a la que la rana debe estar para volver a unirse
    private bool isBeingDragged = false;
    private bool isDropped = false;

    // private bool isBeingDragged = false; // Si la rana está siendo arrastrada
    Vector3 offset; // Offset para arrastrar correctamente
    // private bool shouldReturnToChain = false; // Controla si la rana debería regresar a la cadena

    void Update()
    {
        distanceBetween = Vector2.Distance(transform.position, animeGirl.transform.position);
        if (distanceBetween >= 7)
        {
            transform.position = Vector2.MoveTowards(transform.position, animeGirl.transform.position, speed * Time.deltaTime);
        }
    }

    void OnMouseDown()
    {
        if (!isDropped)
        {
            isBeingDragged = true;
            offset = transform.position - GetMouseWorldPosition();
        }
    }

    void OnMouseDrag()
    {
        if (isBeingDragged)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    void OnMouseUp()
    {
        if (isBeingDragged) // Al soltar el botón del ratón
        {
            isBeingDragged = false;
            isDropped = true; // Marcar la rana como "dropeada"
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}