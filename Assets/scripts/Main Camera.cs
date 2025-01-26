using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform targetFollow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(targetFollow.position.x, 1f, 10f),
            Mathf.Clamp(targetFollow.position.y, -3.5f, 6f),
            transform.position.z
            );
    }
}
