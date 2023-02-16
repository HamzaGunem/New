using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb;
    Vector2 targetPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector2 movements = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetPos = movements.normalized * speed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + targetPos * Time.fixedDeltaTime);
    }
}
