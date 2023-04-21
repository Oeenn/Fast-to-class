using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private float dirX = 0;
    private Transform sprite;
    [SerializeField] private float movespeed = 25f;
    [SerializeField] private float jumpforce = 25;
    [SerializeField] public LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpsound;
    [SerializeField] private float sizex = 3;
    [SerializeField] private float sizey = 3;


    private enum movementState {runing, idle, falling, jumping}
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<Transform>();
        sprite.transform.localScale = new Vector2(sizex, sizey);

    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y);

        UpdateAnimation();

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpsound.time = 0f;
            jumpsound.Play();
            rb.velocity = new Vector2(0, jumpforce);
        }
    }

    private void UpdateAnimation()
    {
        movementState state;
        if (dirX > 0f)
        {
            state = movementState.runing;
            sprite.transform.localScale = new Vector2(sizex,sizey);

        }
        else if (dirX < 0f)
        {
            state = movementState.runing;
            
            sprite.transform.localScale = new Vector2(-sizex,sizey);
        }
        else
        {
            state = movementState.idle;
        }

        if(rb.velocity.y>.01f)
        {
            state = movementState.jumping;
        }
        else if (rb.velocity.y < -0.01f)
        {
            state = movementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);       

    }
}
