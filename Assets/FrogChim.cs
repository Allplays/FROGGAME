using UnityEngine;

public class FrogChim : MonoBehaviour
{
    [SerializeField] private GameObject animeGirl;
    [SerializeField] private GameObject[] itemPrefabs; 
    [SerializeField] private float speed = 2f;

    private float distanceBetween;
    private bool isBeingDragged = false;
    private bool isDropped = false;
    private bool working = false;

    public int counter;

    Vector3 offset;

    void Update()
    {
        distanceBetween = Vector2.Distance(transform.position, animeGirl.transform.position);
        if (distanceBetween >= 5 && !working)
        {
            transform.position = Vector2.MoveTowards(transform.position, animeGirl.transform.position, speed * Time.deltaTime);
        }
        if (counter > 100 && working)
        {
            DoneWorking();
        }
        else if (working)
        {
            counter++;
        }
    }
    private void Start()
    {
        animeGirl = AnimeGirl.current.gameObject;
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
            working = true;
            counter = 0;
            Debug.Log("Recogiendo item");
        }
    }

    void DoneWorking()
    {
        Vector3 spawnPosition = transform.position + Vector3.down * 0.5f;

        int randomIndex = Random.Range(0, itemPrefabs.Length); 
        if (itemPrefabs[randomIndex] != null)
        {
            Instantiate(itemPrefabs[randomIndex], spawnPosition, Quaternion.identity);
            Debug.Log($"Item instanciado: {itemPrefabs[randomIndex].name}");
        }

        working = false;
        isDropped = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
