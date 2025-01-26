using UnityEngine;

public class Frogs : MonoBehaviour
{
    [SerializeField] private GameObject animeGirl;
    [SerializeField] private GameObject poopPrefab;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float poopDelay = 4f;

    private float distanceBetween;
    private Vector3 offset;
    private bool isBeingDragged = false;
    private bool isDropped = false;
    private float poopTimer = 0f;
    private Animator frogAnimator;
    private bool isNearRot = false;
    private GameObject currentRot = null;

    void Start()
    {
        frogAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        
        frogAnimator.SetBool("isDragged", isBeingDragged);

        if (isDropped && isNearRot)
        {
            frogAnimator.SetBool("isEating", true);
            poopTimer += Time.deltaTime;

            if (poopTimer >= poopDelay)
            {
                SpawnPoop();
                poopTimer = 0f;
                isDropped = false;
                frogAnimator.SetBool("isEating", false);

                if (currentRot != null)
                {
                    Destroy(currentRot); 
                    currentRot = null; 
                    isNearRot = false;
                }
            }
        }
        else if (isDropped && !isNearRot)
        {
            frogAnimator.SetBool("isEating", false);
            poopTimer = 0f;
            isDropped = false;
        }

        
        distanceBetween = Vector2.Distance(transform.position, animeGirl.transform.position);
        if (distanceBetween >= 3 && !isBeingDragged && !isDropped)
        {
            transform.position = Vector2.MoveTowards(transform.position, animeGirl.transform.position, speed * Time.deltaTime);
        }
    }

    void OnMouseDown()
    {
        isBeingDragged = true;
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        if (isBeingDragged)
            transform.position = GetMouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        if (isBeingDragged)
        {
            isBeingDragged = false;
            isDropped = true; 
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rot")) 
        {
            isNearRot = true;
            currentRot = collision.gameObject; 
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Rot"))
        {
            isNearRot = false;
            currentRot = null; 
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
