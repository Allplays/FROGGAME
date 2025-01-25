using UnityEngine;

public class FrogsChimi : MonoBehaviour
{
    [SerializeField] private GameObject animeGirl; // Referencia al objeto AnimeGirl
    [SerializeField] private float followSpeed = 2.5f; // Velocidad de seguimiento
    [SerializeField] private float followDistance = 1.5f; // Distancia mínima para mantener con AnimeGirl
    [SerializeField] private float reFollowDelay = 5f; // Tiempo antes de reanudar el seguimiento
    [SerializeField] private float minDistanceBetweenFrogs = 1.2f; // Distancia mínima entre ranitas
    [SerializeField] private float separationForce = 2f; // Fuerza de separación entre ranitas
    [SerializeField] private float collectRadius = 1.5f; // Radio para recoger la caca
    [SerializeField] private LayerMask poopLayer; // Layer para identificar las cacas
    private bool isBeingDragged = false; // Indica si la rana está siendo arrastrada
    private bool shouldFollowAnimeGirl = true; // Controla si la rana debe seguir a AnimeGirl
    private Vector3 offset; // Diferencia entre el mouse y la rana para arrastrar correctamente

    void Update()
    {
        // Si no está siendo arrastrada y debe seguir a AnimeGirl
        if (!isBeingDragged && shouldFollowAnimeGirl && animeGirl != null)
        {
            FollowAnimeGirl();
        }

        // Asegurar distancia mínima entre ranitas
        MaintainDistanceBetweenFrogs();
    }

    void FollowAnimeGirl()
    {
        // Calcular la distancia actual entre la rana y AnimeGirl
        float currentDistance = Vector3.Distance(transform.position, animeGirl.transform.position);

        // Si la distancia actual es mayor que la distancia mínima, mover la rana hacia AnimeGirl
        if (currentDistance > followDistance)
        {
            // Direccionamos hacia AnimeGirl y usamos Lerp para un movimiento suave
            Vector3 direction = (animeGirl.transform.position - transform.position).normalized;
            Vector3 targetPosition = animeGirl.transform.position - direction * followDistance; // Calcula la posición deseada manteniendo la distancia
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
        }
    }

    private void MaintainDistanceBetweenFrogs()
    {
        // Obtener todas las ranitas en la escena
        FrogsChimi[] allFrogs = FindObjectsOfType<FrogsChimi>();

        foreach (FrogsChimi otherFrog in allFrogs)
        {
            if (otherFrog != this) // No queremos calcular la distancia consigo misma
            {
                float distance = Vector3.Distance(transform.position, otherFrog.transform.position);

                // Si la distancia es menor a la mínima permitida, aplicar una fuerza de separación
                if (distance < minDistanceBetweenFrogs)
                {
                    // Calcular dirección de separación
                    Vector3 separationDirection = (transform.position - otherFrog.transform.position).normalized;

                    // Mover la rana un poco lejos de la otra
                    transform.position += separationDirection * separationForce * Time.deltaTime;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        // Al hacer clic en la rana, calculamos la diferencia entre la posición del mouse y la rana
        offset = transform.position - GetMouseWorldPosition();
        isBeingDragged = true; // Indica que la rana está siendo arrastrada
    }

    private void OnMouseDrag()
    {
        // Mientras se arrastra, actualiza la posición de la rana según el mouse
        transform.position = GetMouseWorldPosition() + offset;
        shouldFollowAnimeGirl = false; // Detenemos el seguimiento mientras se arrastra
    }

    private void OnMouseUp()
    {
        // Cuando se suelta, la rana deja de ser arrastrada
        isBeingDragged = false;
        shouldFollowAnimeGirl = false; // Detenemos el seguimiento después de soltarla

        // Inicia un temporizador para reanudar el seguimiento
        Invoke("ResumeFollowing", reFollowDelay);

        // Recolectar caca si está cerca
        CollectPoop();
    }

    private void CollectPoop()
    {
        // Usamos OverlapCircle para detectar cacas cercanas
        Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(transform.position, collectRadius, poopLayer);

        foreach (Collider2D obj in nearbyObjects)
        {
            if (obj.CompareTag("CacaLennon")) // Verificar si el objeto tiene la etiqueta "CacaLennon"
            {
                Destroy(obj.gameObject); // Eliminar la caca
                Debug.Log("CacaLennon recolectada por FrogChimi.");
            }
        }
    }

    private void ResumeFollowing()
    {
        // Método para reanudar el seguimiento a AnimeGirl
        shouldFollowAnimeGirl = true;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Convierte la posición del mouse en coordenadas del mundo 3D
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z; // Mantiene la misma distancia en Z
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnDrawGizmosSelected()
    {
        // Dibujar el radio de recolección en la vista de escena para depuración
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, collectRadius);
    }
}
