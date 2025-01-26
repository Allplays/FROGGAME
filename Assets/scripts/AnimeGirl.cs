using UnityEngine;

public class AnimeGirl : MonoBehaviour
{
    public static AnimeGirl current;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Animator animator; 
    [SerializeField] AudioSource animeGirlStepSfx;
    private void Awake()
    {
        current = this;
    }
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

        
        //if (Input.GetKeyDown("w")) animeGirlStepSfx.Play();
        //else if (Input.GetKeyDown("s")) animeGirlStepSfx.Play();
        //else if (Input.GetKeyDown("a")) animeGirlStepSfx.Play();
        //else if (Input.GetKeyDown("d")) animeGirlStepSfx.Play();
        
        //if (!isMovingDown && !isMovingLeft && !isMovingRight && !isMovingUp) animeGirlStepSfx.Stop();

        transform.position = pos;
        transform.rotation = Quaternion.identity;
        animator.SetBool("isMovingUp", isMovingUp);       
        animator.SetBool("isMovingDown", isMovingDown);  
        animator.SetBool("isMovingLeft", isMovingLeft);  
        animator.SetBool("isMovingRight", isMovingRight);  
    }
}
