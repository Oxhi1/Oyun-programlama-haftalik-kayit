using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 500f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());

        // Mermiyi ileriye fiziksel kuvvetle fırlat
        rb.AddForce(firePoint.forward * bulletForce);
    }
}
