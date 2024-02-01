using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public float jumpForce = 15f;
    private bool isGrounded;
    private bool fallingBlock;
    private Vector3 direction;


    private Rigidbody rb;


    void Start()
    {
        rb=gameObject.GetComponent<Rigidbody>();
    }



    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        direction = new Vector3(horizontal, 0, vertical).normalized;
        if(direction.magnitude >= 0.1)
        {
            if (isGrounded)
            {
                transform.position = direction * Time.deltaTime * speed + transform.position;
            }
            else if(!isGrounded)
            {
                transform.position = direction * Time.deltaTime * speed/10 + transform.position;
            }
            else if (fallingBlock)
            {
                transform.position = direction * Time.deltaTime * speed / 5 + transform.position;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            Jump();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (collision.gameObject.CompareTag("FallingBlock"))
        {
            isGrounded = false;
            fallingBlock = true;
        }
        else
        {
            isGrounded = true;
        }
    }
    private void Jump()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0, vertical).normalized;
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.AddForce(direction * 4f, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
