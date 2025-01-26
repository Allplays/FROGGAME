using UnityEngine;

public class AnimeGirl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Velocidad de movimiento
    [SerializeField] private Animator animator; // Referencia al Animator del personaje
    [SerializeField] AudioSource animeGirlStepSfx;

    void Update()
    {
        Vector3 pos = transform.position; // Posición actual del personaje
        bool isMovingUp = false, isMovingDown = false, isMovingLeft = false, isMovingRight = false;

        // Movimiento y actualización de flags de animación
        if (Input.GetKey("w"))
        {
            pos.y += moveSpeed * Time.deltaTime;
            isMovingUp = true; // Activar el flag de movimiento hacia arriba
        }
        else if (Input.GetKey("s"))
        {
            pos.y -= moveSpeed * Time.deltaTime;
            isMovingDown = true; // Activar el flag de movimiento hacia abajo
        }
        else if (Input.GetKey("a"))
        {
            pos.x -= moveSpeed * Time.deltaTime;
            isMovingLeft = true; // Activar el flag de movimiento hacia la izquierda
        }
        else if (Input.GetKey("d"))
        {
            pos.x += moveSpeed * Time.deltaTime;
            isMovingRight = true; // Activar el flag de movimiento hacia la derecha
        }

        // Actualizar la posición del personaje
        transform.position = pos;

        // Resetear la rotación para que no gire accidentalmente
        transform.rotation = Quaternion.identity;

        // Actualizar los parámetros del Animator
        animator.SetBool("isMovingUp", isMovingUp);    // Activar animación de moverse hacia arriba
        animator.SetBool("isMovingDown", isMovingDown);  // Activar animación de moverse hacia abajo
        animator.SetBool("isMovingLeft", isMovingLeft);  // Activar animación de moverse hacia la izquierda
        animator.SetBool("isMovingRight", isMovingRight);  // Activar animación de moverse hacia la derecha

        while (moveSpeed > 0) {animeGirlStepSfx.Play(); }
    }
}
