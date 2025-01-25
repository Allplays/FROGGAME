using UnityEngine;

public class AnimeGIrl : MonoBehaviour
{
      [SerializeField] private float moveSpeed = 5f; // Velocidad de movimiento


    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= moveSpeed * Time.deltaTime;

        }
        if (Input.GetKey("a"))
        {
            pos.x -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += moveSpeed * Time.deltaTime;
        }
        transform.position = pos;

        transform.rotation = Quaternion.identity;
    }


}


