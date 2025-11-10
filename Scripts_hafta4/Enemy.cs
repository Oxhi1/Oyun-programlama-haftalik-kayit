using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int speed = 4;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -5.5f)
        {
            transform.position = new Vector3(Random.Range(-9.5f, 9.5f), 7.4f, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("çarpışma: " + other.tag);

        if (other.tag == "Player")
        {
            PlayerController playerController = other.transform.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.Damage();
            }

            Destroy(gameObject);
        }
        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
