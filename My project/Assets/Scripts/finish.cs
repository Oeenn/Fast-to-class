using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class finish : MonoBehaviour
{
    private AudioSource finishsound;
    private bool levelcompleted = false;

    void Start()
    {
        finishsound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelcompleted) 
        { 
            finishsound.time = 0f;
            finishsound.Play();
            Invoke("CompleteLevel", 1f);
            levelcompleted = true;

            

        }
    }
    private void CompleteLevel()
    {
        //scenes are ordered in the build manager. Buildindex + 1 loads next scene (level)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
