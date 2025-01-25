using UnityEngine;

public class Frog : MonoBehaviour
{
    [SerializeField] private GameObject animeGirl; // Referencia al objeto AnimeGirl
    [SerializeField] private float followSpeed = 2.5f; // Velocidad de seguimiento
    [SerializeField] private float followDistance = 1.5f; // Distancia mínima para mantener con AnimeGirl
    [SerializeField] private float minDistanceBetweenFrogs = 1.2f; // Distancia mínima entre ranitas
    [SerializeField] private float separationForce = 2f; // Fuerza de separación entre ranitas
    [SerializeField] private GameObject cacaPrefab; // Prefab de la caca que será instanciada
    private bool isBeingDragged = false; // Indica si la rana está siendo arrastrada
    private bool shouldFollowAnimeGirl = true; // Controla si la rana debe seguir a AnimeGirl
    private Vector3 offset; // Diferencia entre el mouse y la rana para arrastrar correctamente
    private float reFollowRange = 2f; // Rango para volver a seguir a la Anime Girl

    void Update()
    {
        if (!isBeingDragged && shouldFollowAnimeGirl && animeGirl != null)
        {
            FollowAnimeGirl();
        }

        // Asegurar distancia mínima entre ranitas
        MaintainDistanceBetweenFrogs();
    }

    void FollowAnimeGirl()
    {
        float currentDistance = Vector3.Distance(transform.position, animeGirl.transform.position);

        if (currentDistance > followDistance)
        {
            Vector3 direction = (animeGirl.transform.position - transform.position).normalized;
            Vector3 targetPosition = animeGirl.transform.position - direction * followDistance;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
        }
    }

    private void MaintainDistanceBetweenFrogs()
    {
        Frog[] allFrogs = FindObjectsOfType<Frog>();

        foreach (Frog otherFrog in allFrogs)
        {
            if (otherFrog != this)
            {
                float distance = Vector3.Distance(transform.position, otherFrog.transform.position);

                if (distance < minDistanceBetweenFrogs)
                {
                    Vector3 separationDirection = (transform.position - otherFrog.transform.position).normalized;
                    transform.position += separationDirection * separationForce * Time.deltaTime;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPosition();
        isBeingDragged = true;
        shouldFollowAnimeGirl = false; // Detenemos el seguimiento
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + offset;
    }

    private void OnMouseUp()
    {
        isBeingDragged = false;

        // Generar una caca al soltar
        Poop();

        // Detectar si la rana está cerca de la Anime Girl
        float distanceToAnimeGirl = Vector3.Distance(transform.position, animeGirl.transform.position);
        if (distanceToAnimeGirl <= reFollowRange)
        {
            // Si está cerca de la Anime Girl, reanudar el seguimiento
            shouldFollowAnimeGirl = true;
        }
    }

    private void Poop()
    {
        if (cacaPrefab != null)
        {
            Vector3 poopPosition = transform.position + Vector3.down * 0.5f;
            Instantiate(cacaPrefab, poopPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Caca prefab no asignado en el inspector.");
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
