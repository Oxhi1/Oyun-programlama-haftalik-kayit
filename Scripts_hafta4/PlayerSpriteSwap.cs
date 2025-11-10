using UnityEngine;

public class PlayerSpriteSwap : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;

    [Header("Sprites")]
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private Sprite leftSprite;

    [Tooltip("Hareket yönünü Input'tan mı yoksa Rigidbody2D hızından mı okuyalım?")]
    [SerializeField] private bool useRigidbodyVelocity = true;

    private int lastSign = 1; 

    private void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float dirX = useRigidbodyVelocity && rb != null
            ? rb.linearVelocity.x
            : Input.GetAxisRaw("Horizontal");

        if (dirX > 0.01f)
        {
            spriteRenderer.sprite = rightSprite;
            lastSign = 1;
        }
        else if (dirX < -0.01f)
        {
            spriteRenderer.sprite = leftSprite;
            lastSign = -1;
        }
        
    }
}