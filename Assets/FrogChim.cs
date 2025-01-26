using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine; 

public class FrogChim : MonoBehaviour
{
    [SerializeField] private GameObject animeGirl; // Referencia al objeto Anime Girl
                                                   // [SerializeField] private GameObject poopPrefab; // Prefab de la "caca"
    [SerializeField] private float speed = 2f; // Distancia a la que la rana debe estar para volver a unirse
    private float distanceBetween;  // Distancia a la que la rana debe estar para volver a unirse
    private bool isBeingDragged = false;
    private bool isDropped = false;
    private bool working = false;

    public int counter;

    Vector3 offset;

    // private bool isBeingDragged = false; // Si la rana está siendo arrastrada
     // Offset para arrastrar correctamente
    // private bool d = false; // Controla si la rana debería regresar a la cadena

    void Update()
    {
        distanceBetween = Vector2.Distance(transform.position, animeGirl.transform.position);
        if (distanceBetween >= 5 & !working)
        {
            transform.position = Vector2.MoveTowards(transform.position, animeGirl.transform.position, speed * Time.deltaTime);
        }
        if (counter > 5000 & working)
        {
            doneWorking();
        }
        else if(working)
        {
            counter++;
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
            isDropped = true;
            working = true;
            counter = 0;
            Debug.Log("Recogiendo item");
        }
    }

    void doneWorking()
    {
        simpleInventory.current.holding[checkTask()]++;
        Debug.Log("Item recogido");
        working = false;
        isDropped = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    int checkTask()
        {
            if (this.gameObject.transform.position.x < 0 & this.gameObject.transform.position.y < 0)
            {
                return 0;
            }
            else if(this.gameObject.transform.position.x < 0 & this.gameObject.transform.position.y >= 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }

        }

}