using UnityEngine;

public class Bonus_sc : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -5.8f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Üçlü atış bonusunu aktifleştir
            PlayerController playerController = other.transform.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TripleShotActive();
            }

            // Bonus nesnesini yok et
            Destroy(gameObject);
        }
    }
}
