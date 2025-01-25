using UnityEngine;

public class FrogsChain : MonoBehaviour
{
    [SerializeField] private GameObject target; // Objetivo de esta ranita
    [SerializeField] private float followSpeed = 3f; // Velocidad de movimiento
    [SerializeField] private float followDistance = 1.5f; // Distancia mínima con el objetivo

    private Rigidbody2D rb; // Referencia al Rigidbody2D

    void Start()
    {
        // Obtener el Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        if (target == null) return;

        // Calcular la distancia al objetivo
        float distance = Vector2.Distance(transform.position, target.transform.position);

        // Si la distancia es mayor que la mínima, moverse hacia el objetivo
        if (distance > followDistance)
        {
            Vector2 direction = ((Vector2)target.transform.position - rb.position).normalized;
            Vector2 targetPosition = (Vector2)target.transform.position - direction * followDistance;

            // Movimiento suave usando interpolación
            rb.MovePosition(Vector2.Lerp(rb.position, targetPosition, followSpeed * Time.fixedDeltaTime));
        }
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }
}


