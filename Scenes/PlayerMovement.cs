using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        
        
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.fixedDeltaTime;
        Vector3 movement = transform.forward * move;
        rb.MovePosition(rb.position + movement);

        
        float rotate = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        transform.Rotate(Vector3.up * rotate);
    }
}

