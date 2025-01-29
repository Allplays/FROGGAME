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

    float enemyIdleSfxTimer;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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
            audioManager.PlayEnemySfx(audioManager.enemyDeathSfx);

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
            this.GetComponent<Transform>().position = new Vector3(this.GetComponent<Transform>().position.x, this.GetComponent<Transform>().position.y+0.001f, this.GetComponent<Transform>().position.z);
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

        if (!dead)
        {
            enemyIdleSfxTimer += Time.deltaTime;
            if (enemyIdleSfxTimer >= audioManager.enemyIdleSfxDuration)
            {
                audioManager.PlayEnemySfx(audioManager.enemyIdleSfx);
                enemyIdleSfxTimer = -7;
            }
        }
    }
}
