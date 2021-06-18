using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateRate = 120f;
    public float moveRate = 30f;
    public Slider speed;

    private Rigidbody2D rb;
    private Quaternion targetLeftRotation;
    private Quaternion targetRightRotation;
    private Quaternion initialRotation;

    Vector2 movement;
    void Start()
    {
        speed.value = moveSpeed;
        initialRotation = transform.rotation;
        targetLeftRotation = Quaternion.Euler(-90, 0, -30f);
        targetRightRotation = Quaternion.Euler(-90, 0, 30f);
        rb = GetComponent<Rigidbody2D>();
        movement = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveSpeed > 8)
        {
            moveSpeed = 8f;
        }
        speed.value = moveSpeed;
        movement.x = Mathf.Lerp(movement.x, Input.GetAxisRaw("Horizontal"), moveRate * Time.deltaTime);
        if (movement.x > 0.5)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetLeftRotation, rotateRate * Time.deltaTime);
        }
        else if (movement.x < -0.5)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRightRotation, rotateRate * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, initialRotation, 2 * rotateRate * Time.deltaTime);
        }
        if(transform.position.x > 7f)
        {
            transform.position = new Vector3(7f, -4.25f, 10);
        }
        if (transform.position.x < -7f)
        {
            transform.position = new Vector3(-7f, -4.25f, 10);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


}
