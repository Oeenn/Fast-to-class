using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    public GameObject[] images;
    private int index = 0;
 
    void Start()
    {
        Debug.Log(images.Length);
        index = 0;
        for (int i = 0; i <= images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
            images[index].gameObject.SetActive(true);

        }
    }

    void Update()
    {
        //since the countdown timer script is not in the tutorial, if esc is pressed, reset variables and go to menu in same fashion
        if (Input.GetButton("Cancel"))
        {

            gameObject.SetActive(false);
            SceneManager.LoadScene(0);
            finish_success.COMPLETE = false;
            Audiocontrol.played = false;
            countdowntimer.timeup = false;
            Playerlife.death = false;
            Audiocontrol.index = 0;
            finish.progression = false;
            finish.count = 0;

        }
    }
    public void Next()
    {
        //make sure that index is always a valid list index, and move forward in the list of images when the routine is called
        index+= 1;
        Debug.Log(index);
        if (index >= images.Length)
        {
            index = 0;
        }
        Debug.Log(index);
        for (int i = 0; i<= images.Length; i++)
        {
            
            images[i].gameObject.SetActive(false);
            images[index].gameObject.SetActive(true);
            if (i == images.Length)
            {
                images[0].gameObject.SetActive(true);
            }
        }
        
    }

    
    public void Prev()
    {
        //unused module for cycling backwards in the slideshow
        index-= 1;
        if (index < 0)
        {
            index = images.Length;
        }

        for (int i = images.Length; i >= 0; i--)
        {
            images[i].gameObject.SetActive(false);
            images[index].gameObject.SetActive(true);
            
        }
        Debug.Log(index);
    }
}
