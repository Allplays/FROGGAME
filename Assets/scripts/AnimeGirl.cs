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
        transform.position = pos;
        transform.rotation = Quaternion.identity;
        animator.SetBool("isMovingUp", isMovingUp);       
        animator.SetBool("isMovingDown", isMovingDown);  
        animator.SetBool("isMovingLeft", isMovingLeft);  
        animator.SetBool("isMovingRight", isMovingRight);  

       //hile (moveSpeed > 0) {animeGirlStepSfx.Play(); }
    }
}
