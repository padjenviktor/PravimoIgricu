using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropadanjeBloka : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    void Start()
    {
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
            rb.AddForce(new Vector3(0,-3f,0f), ForceMode.Impulse);
        }


    }
}
