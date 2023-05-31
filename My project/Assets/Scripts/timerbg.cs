using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerbg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Cancel"))
        {

            gameObject.SetActive(false);

        }

        if (countdowntimer.currentTime < 0)
        {
            gameObject.SetActive(false);

        }
        
        if (finish_success.hide == true)
        {
            //gameObject.SetActive(false);
            DestroyObject(gameObject);
        }
    }
}
