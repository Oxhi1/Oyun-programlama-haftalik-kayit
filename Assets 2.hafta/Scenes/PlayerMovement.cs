using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;         // Normal hız
    public float sprintMultiplier = 2f;  // Ctrl ile hız çarpanı
    public float rotationSpeed = 100f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; 
    }

    void FixedUpdate()
    {
        
        float currentSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftControl)) 
        {
            currentSpeed *= sprintMultiplier; 
        }

        
        float move = Input.GetAxis("Vertical") * currentSpeed * Time.fixedDeltaTime;
        Vector3 movement = transform.forward * move;
        rb.MovePosition(rb.position + movement);

       
        float rotate = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        transform.Rotate(Vector3.up * rotate);
    }
}