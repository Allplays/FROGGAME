using UnityEngine;

public class Frogs : MonoBehaviour
{
    [SerializeField] private GameObject animeGirl;
    [SerializeField] private GameObject poopPrefab;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float poopDelay = 4f;

    private float distanceBetween;
    private Vector3 offset;
    private bool isBeingDragged = false;
    private bool isDropped = false;
    private float poopTimer = 0f;
    private Animator frogAnimator;
    private bool isNearRot = false;
    private GameObject currentRot = null;

    void Start()
    {
        frogAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Animación de "isDragged"
        frogAnimator.SetBool("isDragged", isBeingDragged);

        if (isDropped && isNearRot)
        {
            frogAnimator.SetBool("isEating", true);
            poopTimer += Time.deltaTime;

            if (poopTimer >= poopDelay)
            {
                SpawnPoop();
                poopTimer = 0f;
                isDropped = false;
                frogAnimator.SetBool("isEating", false);

                if (currentRot != null)
                {
                    Destroy(currentRot); // Destruir el objeto "Rot" que está cerca
                    currentRot = null; // Reiniciar la referencia
                    isNearRot = false;
                }
            }
        }
        else if (isDropped && !isNearRot)
        {
            frogAnimator.SetBool("isEating", false);
            poopTimer = 0f;
            isDropped = false;
        }

        // Movimiento automático hacia "animeGirl"
        distanceBetween = Vector2.Distance(transform.position, animeGirl.transform.position);
        if (distanceBetween >= 3 && !isBeingDragged && !isDropped)
        {
            transform.position = Vector2.MoveTowards(transform.position, animeGirl.transform.position, speed * Time.deltaTime);
        }
    }

    void OnMouseDown()
    {
        isBeingDragged = true;
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        if (isBeingDragged)
            transform.position = GetMouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        if (isBeingDragged)
        {
            isBeingDragged = false;
            isDropped = true; // Marca que se soltó
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rot")) // Verifica si el objeto tiene el tag "Rot"
        {
            isNearRot = true;
            currentRot = collision.gameObject; // Guarda el objeto "Rot" con el que está colisionando
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Rot"))
        {
            isNearRot = false;
            currentRot = null; // Limpia la referencia del objeto "Rot"
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void SpawnPoop()
    {
        if (poopPrefab != null)
        {
            Vector3 poopPosition = transform.position + Vector3.down * 0.5f;
            Instantiate(poopPrefab, poopPosition, Quaternion.identity);
        }
    }
}
