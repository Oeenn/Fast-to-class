using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonPMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private PolygonCollider2D coll;
    private Animator anim;

    [SerializeField] public LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpsound;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<PolygonCollider2D>();
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * 12f, rb.velocity.y);
        
        if(dirX > 0f)
        {
            anim.SetBool("runing", true);
        }
        else if(dirX < 0f)
        {
            anim.SetBool("runing", true);
        }
        else
        {
            anim.SetBool("runing", false);
        }

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpsound.time = 0f;
            jumpsound.Play();
            rb.velocity = new Vector2(0, 14f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);       

    }
}
