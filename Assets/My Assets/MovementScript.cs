using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float verticalSpeed = 2.0f;
    public float horizontalSpeed = 5.0f;
    private Rigidbody2D rb;
    private Animator anim;
    Vector2 movement;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal")*horizontalSpeed;
        movement.y = Input.GetAxis("Vertical")*verticalSpeed;
        anim.SetFloat("horizontal", movement.x);
        anim.SetFloat("speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}
