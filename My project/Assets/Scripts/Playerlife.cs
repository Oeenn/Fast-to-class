using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerlife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    
    public static bool death = false;
    [SerializeField] AudioClip[] deathclips;
    
    AudioSource myaudioclip;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myaudioclip = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check collision is with a hazard
        if (collision.gameObject.CompareTag("Hazards")) 
        { 
            Die();
            
            death = true;
        }
       
    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        death = false;
        AudioClip ded = deathclips[UnityEngine.Random.Range(0, deathclips.Length)];
        myaudioclip.PlayOneShot(ded);
    }

    //Restartlevel() is called by the death animation, once the animation is finished, this module will run
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
