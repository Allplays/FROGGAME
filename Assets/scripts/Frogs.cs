using UnityEngine;

public class Frogs : MonoBehaviour
{
    [SerializeField] private GameObject animeGirl;
    [SerializeField] private GameObject poopPrefab;
    [SerializeField] private GameObject rotObjectToDestroy; 
    [SerializeField] private float speed = 2f;
    [SerializeField] private float poopDelay = 5f;

    private float distanceBetween;
    Vector3 offset;
    private bool isBeingDragged = false;
    private bool isDropped = false;
    private float poopTimer = 0f;

    private Animator frogAnimator;

    private bool isCollidingWithRot = false; 
    private float rotDestructionTimer = 0f; 

    void Start()
    {
        frogAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (isBeingDragged)
        {
            frogAnimator.SetBool("isDragged", true);
        }
        else
        {
            frogAnimator.SetBool("isDragged", false);
        }

        if (isDropped)
        {
            frogAnimator.SetBool("isEating", true);
            poopTimer += Time.deltaTime;
            if (poopTimer >= poopDelay)
            {
                SpawnPoop();
                poopTimer = 0f;
                isDropped = false;
                frogAnimator.SetBool("isEating", false);
            }
        }

        if (!isBeingDragged && !isDropped)
        {
            frogAnimator.SetBool("isEating", false);
        }

        
        distanceBetween = Vector2.Distance(transform.position, animeGirl.transform.position);
        if (distanceBetween >= 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, animeGirl.transform.position, speed * Time.deltaTime);
        }


        if (isCollidingWithRot && rotObjectToDestroy != null)
        {
            rotDestructionTimer += Time.deltaTime;
            if (rotDestructionTimer >= 3f) 
            {
                Destroy(rotObjectToDestroy);
                isCollidingWithRot = false; 
                rotDestructionTimer = 0f; 
            }
        }
    }

    void OnMouseDown()
    {
        if (!isDropped)
        {
            isBeingDragged = true;
            offset = transform.position - GetMouseWorldPosition();
        }
    }

    void OnMouseDrag()
    {
        if (isBeingDragged)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    void OnMouseUp()
    {
        if (isBeingDragged)
        {
            isBeingDragged = false;
            isDropped = true;
            poopTimer = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == rotObjectToDestroy) 
        {
            isCollidingWithRot = true; 
            rotDestructionTimer = 0f; 
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == rotObjectToDestroy)
        {
            isCollidingWithRot = false; 
            rotDestructionTimer = 0f; 
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void SpawnPoop()
    {
        if (poopPrefab != null)
        {
            Vector3 poopPosition = transform.position + Vector3.down * 0.5f;
            Instantiate(poopPrefab, poopPosition, Quaternion.identity);
        }
    }
}
