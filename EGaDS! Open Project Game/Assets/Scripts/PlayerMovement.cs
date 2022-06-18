using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;

    public float groundCheckerRadius = 0.5f;

    public Transform groundChecker;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.A)) {
            // move left
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        } else if (Input.GetKeyDown(KeyCode.D)) {
            // move right
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded) {
            // Jump up!
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundChecker.position, groundCheckerRadius);
    }
}
