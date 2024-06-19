using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D rb;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groudLayer;
    private bool isTouchingGround;

    private Animator anim;

    public Text WINTEXT;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groudLayer);
        direction = Input.GetAxis("Horizontal");

        if(direction > 0f)
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            transform.localScale = new Vector2(2.0889f, 2.0889f);
        }
        else if(direction < 0f)
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            transform.localScale = new Vector2(-2.0889f, 2.0889f);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }


        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Win")
        {
            WINTEXT.gameObject.SetActive(true);
        }
    }
}
