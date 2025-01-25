using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI current;

    [SerializeField] public GameObject background; 
    [SerializeField] public GameObject marco;

    [SerializeField] public GameObject sprite;
    private Image titleRenderer;

    private void Awake()
    {
        current = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        titleRenderer = sprite.GetComponent<Image>();
        background.SetActive(false);
        marco.SetActive(false);
        sprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenMenu(string title)
    {
        Debug.Log($"Si que se llama la función");
        titleRenderer.sprite = Resources.Load<Sprite>($"titulo_" + title);
        background.SetActive(true);
        marco.SetActive(true);
        sprite.SetActive(true);
    }
}
