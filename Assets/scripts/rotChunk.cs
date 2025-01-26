using UnityEngine;

public class rotChunk : MonoBehaviour
{

    private int animationCounter;
    private int animationIdx;

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites = new Sprite[3];
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        animationCounter = 0;
        animationIdx = 0;
    }

    // Update is called once per frame
    void Update()
    {
        animationCounter++;
        if(animationCounter > 500)
        {
            spriteRenderer.sprite = sprites[animationIdx];
            animationCounter = 0;
            animationIdx++;
        }
        if(animationIdx > 2)
        {
            animationIdx = 0;
        }
    }
}
