using UnityEngine;

public class AnimeGirl : MonoBehaviour
{
    public static AnimeGirl current;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Animator animator;

    AudioManager audioManager;

    float stepsSfxTimer;

    private void Awake()
    {
        current = this;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        stepsSfxTimer = audioManager.stepsSfxDuration;
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

        if (isMovingUp | isMovingDown | isMovingLeft | isMovingRight)
        { 
            stepsSfxTimer += Time.deltaTime;
            if (stepsSfxTimer >= audioManager.stepsSfxDuration)
            { 
                audioManager.PlayAnimeGirlSfx(audioManager.stepsSfx);
                stepsSfxTimer = 0;
            }
        }
        else
        { 
            audioManager.StopAnimeGirlSfx(); 
            stepsSfxTimer = audioManager.stepsSfxDuration;
        }

        transform.position = pos;
        transform.rotation = Quaternion.identity;
        animator.SetBool("isMovingUp", isMovingUp);       
        animator.SetBool("isMovingDown", isMovingDown);  
        animator.SetBool("isMovingLeft", isMovingLeft);  
        animator.SetBool("isMovingRight", isMovingRight);  
    }
}
