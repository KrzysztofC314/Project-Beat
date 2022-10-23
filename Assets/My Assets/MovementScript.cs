using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float verticalSpeed = 2.0f;
    public float horizontalSpeed = 5.0f;
    private Rigidbody2D rb;
    Vector2 movement;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal")*horizontalSpeed;
        movement.y = Input.GetAxis("Vertical")*verticalSpeed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}
