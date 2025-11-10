using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private Vector2 xLimits = new Vector2(-9.5f, 9.5f);
    [SerializeField] private Vector2 yLimits = new Vector2(-4.5f, 4.5f);

    [Header("Combat")]
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 0.25f;

    [Header("Health")]
    [SerializeField] private int lives = 3;

    [Header("Triple Shot")]
    [SerializeField] private float tripleShotDuration = 5f;

    [Header("Visual")]
    [SerializeField] private SpriteRenderer spriteRenderer; // yön için
    [SerializeField] private bool useFlipInsteadOfSwap = true;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private Sprite leftSprite;

    private float _canFireTime;
    private bool _tripleShotActive;
    private SpawnManager _spawnManager;

    void Start()
    {
        _spawnManager = FindObjectOfType<SpawnManager>();
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    private void HandleMovement()
    {
        // Eski Input sistemi (Horizontal/Vertical)
        float h = Input.GetAxisRaw("Horizontal"); // A/D, Sol/Sağ
        float v = Input.GetAxisRaw("Vertical");   // W/S, Yukarı/Aşağı

        Vector3 dir = new Vector3(h, v, 0f).normalized;
        transform.Translate(dir * moveSpeed * Time.deltaTime);

        // Sınırları clamp et
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, xLimits.x, xLimits.y);
        pos.y = Mathf.Clamp(pos.y, yLimits.x, yLimits.y);
        transform.position = pos;

        // Yön görseli
        if (dir.x > 0.01f)
        {
            if (useFlipInsteadOfSwap && spriteRenderer != null)
                spriteRenderer.flipX = false;
            else if (spriteRenderer != null && rightSprite != null)
                spriteRenderer.sprite = rightSprite;
        }
        else if (dir.x < -0.01f)
        {
            if (useFlipInsteadOfSwap && spriteRenderer != null)
                spriteRenderer.flipX = true;
            else if (spriteRenderer != null && leftSprite != null)
                spriteRenderer.sprite = leftSprite;
        }
    }

    private void HandleShooting()
    {
        // Space tuşuna basılıyken ateş
        if (Input.GetKey(KeyCode.Space) && Time.time >= _canFireTime)
        {
            _canFireTime = Time.time + fireRate;

            if (laserPrefab == null)
            {
                Debug.LogWarning("Laser Prefab bağlı değil!");
                return;
            }

            if (firePoint == null)
            {
                Debug.LogWarning("FirePoint bağlı değil!");
                return;
            }

            if (_tripleShotActive)
            {
                Instantiate(laserPrefab, firePoint.position + Vector3.left * 0.3f, Quaternion.identity);
                Instantiate(laserPrefab, firePoint.position, Quaternion.identity);
                Instantiate(laserPrefab, firePoint.position + Vector3.right * 0.3f, Quaternion.identity);
            }
            else
            {
                Instantiate(laserPrefab, firePoint.position, Quaternion.identity);
            }
        }
    }

    public void Damage()
    {
        lives--;
        if (lives <= 0)
        {
            if (_spawnManager != null)
                _spawnManager.OnPlayerDeath();

            Destroy(gameObject);
        }
    }

    public void TripleShotActive()
    {
        StopCoroutine(nameof(TripleShotRoutine));
        StartCoroutine(TripleShotRoutine(tripleShotDuration));
    }

    private IEnumerator TripleShotRoutine(float duration)
    {
        _tripleShotActive = true;
        yield return new WaitForSeconds(duration);
        _tripleShotActive = false;
    }
}