using UnityEngine;

public class AnimeGirl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Velocidad de movimiento
    [SerializeField] private Animator animator; // Referencia al Animator del personaje
    [SerializeField] AudioSource animeGirlStepSfx;

    void Update()
    {
        Vector3 pos = transform.position; // Posici�n actual del personaje
        bool isMovingUp = false, isMovingDown = false, isMovingLeft = false, isMovingRight = false;

        // Movimiento y actualizaci�n de flags de animaci�n
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

        // Actualizar la posici�n del personaje
        transform.position = pos;

        // Resetear la rotaci�n para que no gire accidentalmente
        transform.rotation = Quaternion.identity;

        // Actualizar los par�metros del Animator
        animator.SetBool("isMovingUp", isMovingUp);    // Activar animaci�n de moverse hacia arriba
        animator.SetBool("isMovingDown", isMovingDown);  // Activar animaci�n de moverse hacia abajo
        animator.SetBool("isMovingLeft", isMovingLeft);  // Activar animaci�n de moverse hacia la izquierda
        animator.SetBool("isMovingRight", isMovingRight);  // Activar animaci�n de moverse hacia la derecha

        while (moveSpeed > 0) {animeGirlStepSfx.Play(); }
    }
}
