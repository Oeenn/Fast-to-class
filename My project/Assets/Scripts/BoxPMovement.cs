using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private Transform sprite;
    [SerializeField] private float movespeed = 25f;
    [SerializeField] private float jumpforce = 25;
    [SerializeField] public LayerMask jumpableGround;
    [SerializeField] AudioClip[] jumpsounds;
    AudioSource myaudioclip;
    
    [SerializeField] private float sizex = 3;
    [SerializeField] private float sizey = 3;

    //give the 4 states a numerical value (0,1,2,3) to be referenced later (i.e. IF value = 0, run)
    private enum movementState {runing, idle, falling, jumping}
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<Transform>();
        myaudioclip =GetComponent<AudioSource>();
        sprite.transform.localScale = new Vector2(sizex, sizey);


    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y);
        //move player left/right according to 'movespeed'

        UpdateAnimation(); 

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            AudioClip jump = jumpsounds[UnityEngine.Random.Range(0, jumpsounds.Length)];
            myaudioclip.PlayOneShot(jump);
            rb.velocity = new Vector2(0, jumpforce);
            //override current y velocity according to the defined jumpforce
        }
    }

    private void UpdateAnimation()
    {
        //update 'state' according to relevant conditions, these states will be be called by the animator later.
        float dirX = Input.GetAxis("Horizontal");
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
        //check if player is touching a material before confirmation of jump action
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);       

    }
}
