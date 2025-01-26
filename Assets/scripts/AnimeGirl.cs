using UnityEngine;

public class AnimeGirl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Animator animator; 
    [SerializeField] AudioSource animeGirlStepSfx;

    void Update()
    {
        Vector3 pos = transform.position; 
        bool isMovingUp = false, isMovingDown = false, isMovingLeft = false, isMovingRight = false;

        if (Input.GetKey("w"))
        {
            pos.y += moveSpeed * Time.deltaTime;
            isMovingUp = true; 
        }
        else if (Input.GetKey("s"))
        {
            pos.y -= moveSpeed * Time.deltaTime;
            isMovingDown = true; 
        }
        else if (Input.GetKey("a"))
        {
            pos.x -= moveSpeed * Time.deltaTime;
            isMovingLeft = true; 
        }
        else if (Input.GetKey("d"))
        {
            pos.x += moveSpeed * Time.deltaTime;
            isMovingRight = true; 
        }
<<<<<<< HEAD
=======
        
        if (Input.GetKeyDown("w")) animeGirlStepSfx.Play();
        else if (Input.GetKeyDown("s")) animeGirlStepSfx.Play();
        else if (Input.GetKeyDown("a")) animeGirlStepSfx.Play();
        else if (Input.GetKeyDown("d")) animeGirlStepSfx.Play();
        
        if (!isMovingDown && !isMovingLeft && !isMovingRight && !isMovingUp) animeGirlStepSfx.Stop();

        // Actualizar la posici�n del personaje
>>>>>>> 253bbb01d43da9998fa17119d91023aac2a3ba0e
        transform.position = pos;
        transform.rotation = Quaternion.identity;
        animator.SetBool("isMovingUp", isMovingUp);       
        animator.SetBool("isMovingDown", isMovingDown);  
        animator.SetBool("isMovingLeft", isMovingLeft);  
        animator.SetBool("isMovingRight", isMovingRight);  

<<<<<<< HEAD
       //hile (moveSpeed > 0) {animeGirlStepSfx.Play(); }
=======
        // Actualizar los par�metros del Animator
        animator.SetBool("isMovingUp", isMovingUp);    // Activar animaci�n de moverse hacia arriba
        animator.SetBool("isMovingDown", isMovingDown);  // Activar animaci�n de moverse hacia abajo
        animator.SetBool("isMovingLeft", isMovingLeft);  // Activar animaci�n de moverse hacia la izquierda
        animator.SetBool("isMovingRight", isMovingRight);  // Activar animaci�n de moverse hacia la derecha
>>>>>>> 253bbb01d43da9998fa17119d91023aac2a3ba0e
    }
}
