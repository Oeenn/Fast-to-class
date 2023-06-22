using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerbg : MonoBehaviour
{
   
    void Start()
    {
        gameObject.SetActive(true);
    }

    
    void Update()
    {
        //Show and hide the background image for the timer, using the same bool conditions as the timer
        if (Input.GetButton("Cancel"))
        {

            gameObject.SetActive(false);

        }

        if (countdowntimer.timeup == true)
        {
            gameObject.SetActive(false);

        }
        

        if (finish_success.hide == true)
        {
            gameObject.SetActive(false);
            DestroyObject(gameObject);
        }
    }
}
