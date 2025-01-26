/*sing UnityEngine;

public class FrogsChain : MonoBehaviour
{
    [SerializeField] private GameObject animeGirl; // Referencia al objeto Anime Girl
    [SerializeField] private GameObject target; // Objetivo que esta rana debe seguir
    [SerializeField] private float followSpeed = 2.5f; // Velocidad de movimiento
    [SerializeField] private float followDistance = 1.5f; // Distancia mínima con el objetivo
    private Rigidbody2D rb; // Referencia al Rigidbody2D
    private bool isDropped = false; // Indica si la rana ha sido dropeada

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Solo sigue al objetivo si no ha sido dropeada
        if (!isDropped)
        {
            FollowTarget();
        }
    }

    void FollowTarget()
    {
        if (target == null) return;

        // Calcular la distancia al objetivo
        float distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance > followDistance)
        {
            // Calcular la dirección hacia el objetivo
            Vector2 direction = ((Vector2)target.transform.position - rb.position).normalized;

            // Aplicar movimiento al Rigidbody2D
            rb.linearVelocity = direction * followSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero; // Detener el movimiento si está dentro de la distancia mínima
        }
    }

    public void DropFrog()
    {
        // La rana se detiene y deja de seguir al objetivo
        isDropped = true;
        rb.linearVelocity = Vector2.zero; // Detener cualquier movimiento
        rb.bodyType = RigidbodyType2D.Static; // Cambiar a estático para que no interfiera
    }

    public void ReassignFollowers()
    {
        // Encuentra todas las ranas y reasigna su objetivo a la Anime Girl
        FrogsChain[] allFrogs = FindObjectsOfType<FrogsChain>();

        foreach (FrogsChain frog in allFrogs)
        {
            if (frog.target == this.gameObject)
            {
                frog.SetNewTarget(animeGirl); // Asignar el objetivo a Anime Girl
            }
        }
    }

    public void SetNewTarget(GameObject newTarget)
    {
        target = newTarget;
        isDropped = false; // Reactivar el seguimiento
        rb.bodyType = RigidbodyType2D.Dynamic; // Volver a Dynamic para moverse
    }
}
*/