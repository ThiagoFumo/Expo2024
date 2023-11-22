using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemnt : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    float horizontalInput;
    public float horizontzalMultiplaier = 2;

    private void FixedUpdate()
    {
        Vector3 fowardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontzalMultiplaier;
        rb.MovePosition(rb.position + fowardMove + horizontalMove);
    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
}