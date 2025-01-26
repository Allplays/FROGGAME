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
            Mathf.Clamp(targetFollow.position.x, -4.4f, 15f),
            Mathf.Clamp(targetFollow.position.y, -3.8f, 7.3f),
            transform.position.z
            );
    }
}
