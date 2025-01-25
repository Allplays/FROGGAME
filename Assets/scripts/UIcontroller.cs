using UnityEngine;
using UnityEngine.Tilemaps;

public class UIcontroller : MonoBehaviour
{
    public static UIcontroller current;

    [SerializeField] public GameObject sprite;
    private SpriteRenderer titleRenderer;

    [SerializeField] public GameObject backgroudSprite;
    private SpriteRenderer backgroundRenderer;

    [SerializeField] public GameObject MarcoSprite;
    private SpriteRenderer marcoRenderer;

    private void Awake()
    {
        current = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        titleRenderer = sprite.GetComponent<SpriteRenderer>();
        backgroundRenderer = backgroudSprite.GetComponent<SpriteRenderer>();
        marcoRenderer = MarcoSprite.GetComponent<SpriteRenderer>();

        titleRenderer.enabled = false;
        backgroundRenderer.enabled = false;
        marcoRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMenu(string title)
    {
        Debug.Log($"Si que se llama la función");
        titleRenderer.sprite = Resources.Load<Sprite>($"titulo_" + title);

        titleRenderer.enabled = true;
        marcoRenderer.enabled = true;
        backgroundRenderer.enabled = true;
        

    }
}
