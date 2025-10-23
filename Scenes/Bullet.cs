using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5f; 

    void Start()
    {
        
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player")) return;

        
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
