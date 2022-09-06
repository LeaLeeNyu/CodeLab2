using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody2D rb;
    public float xSpeed;
    public float ySpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector2 forceVector = new Vector2(xSpeed * horizontalInput, ySpeed * verticalInput);
        rb.AddForce(forceVector);



    }
}
