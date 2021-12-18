using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float speed = 1;

    [SerializeField]
    float jumpForce = 1;

    Rigidbody rb;

    [SerializeField]
    float rotationSpeed;

    [SerializeField]
    Transform cam;

    public GameObject respawn;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * speed, rb.velocity.y, forwardInput * speed);

        float x = Input.GetAxis("Mouse X") * rotationSpeed;
        float y = Input.GetAxis("Mouse Y") * rotationSpeed;

        transform.Rotate(new Vector3(0, x * rotationSpeed, 0));

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = (camForward * forwardInput * speed) + (camRight * horizontalInput * speed);

        rb.velocity = new Vector3 (moveDirection.x, rb.velocity.y, moveDirection.z);

        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if(transform.position.y < -5)
        {
            transform.position = respawn.transform.position;
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.y);
    }
}
