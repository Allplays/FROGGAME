using UnityEngine;

public class AnimeGirl : MonoBehaviour
{
    // Velocidad de movimiento
    public float moveSpeed = 5f;

    // Referencia al Rigidbody2D
    private Rigidbody2D rb;

    // Movimiento actual del personaje
    private Vector2 movement;

    void Start()
    {
        // Obtener el componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Leer la entrada del teclado
        movement.x = Input.GetAxis("Horizontal"); // A/D (izquierda/derecha)
        movement.y = Input.GetAxis("Vertical");   // W/S (arriba/abajo)
    }

    void FixedUpdate()
    {
        // Mover al personaje usando Rigidbody2D (f�sica 2D)
        rb.linearVelocity = movement * moveSpeed;

        // Opcional: Orientar al personaje hacia la direcci�n del movimiento
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }
}


