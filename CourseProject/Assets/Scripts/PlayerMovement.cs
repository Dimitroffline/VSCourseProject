using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movementVector;
    Animate animate;

    [SerializeField] float speed = 3.0f;

    [HideInInspector] public float lastHorizontalVector;
    [HideInInspector] public float lastVerticalVector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementVector = new Vector2();
        animate = GetComponent<Animate>();
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if(movementVector.x != 0)
        {
            lastHorizontalVector = movementVector.x;
        }
        if(movementVector.y != 0)
        {
            lastVerticalVector = movementVector.y;
        }

        animate.horizontal = movementVector.x;
        animate.vertical = movementVector.y;

        movementVector *= speed;

        rb.velocity = movementVector;
    }
}
