using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class finish_success : MonoBehaviour
{
    [SerializeField] private AudioSource finishsound;
    private bool levelcompleted = false;
    public static bool COMPLETE = false;
    public static bool hide = false;

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
            COMPLETE = true;
            Invoke("CompleteLevel", 1f);
            levelcompleted = true;
            



        }
    }
    public void CompleteLevel()
    {
        //since this object will be in the final level, when the level is complete it should send user to the success screen
        SceneManager.LoadScene("success");
        hide = true;
    }

}
