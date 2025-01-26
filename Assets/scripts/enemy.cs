using UnityEditor;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Sprite[] sprites;
    public Sprite deathSprite;

    private int animationCounter;
    private int animationIdx;

    private bool mouseHovering = false;
    private bool dead = false;
    private float deathTimer = 0;
    private float speed = 3f;

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponentInChildren<SpriteRenderer>();

        animationCounter = 0;
        animationIdx = 0;
    }

    private void OnMouseOver()
    {
        mouseHovering = true;
        //Debug.Log("La hitbox va");
    }

    private void OnMouseExit()
    {
        mouseHovering = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseHovering & Input.GetMouseButtonDown(0) & !dead)
        {
            Debug.Log("Mori");
            dead = true;
            spriteRenderer.sprite = deathSprite;

        }
        else if (animationCounter > 100 & !dead)
        {
            spriteRenderer.sprite = sprites[animationIdx];
            animationCounter = 0;
            animationIdx++;
        }
        if (animationIdx > 2 & !dead)
        {
            animationIdx = 0;
        }
        animationCounter++;
        if (dead)
        {
            deathTimer += Time.deltaTime;
            if (deathTimer > 1)
            {
                Destroy(spriteRenderer);
                Destroy(this);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(3f, 5f), speed * Time.deltaTime);
        }

    }
}
