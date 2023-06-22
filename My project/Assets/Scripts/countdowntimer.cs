using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class countdowntimer : MonoBehaviour
{
    public static float currentTime = 0;
    [SerializeField] float startTime = 60f;
    public static bool timeup = false;
    [SerializeField] public Text CDtext;
    Scene scene1 = SceneManager.GetActiveScene();
   
    void Start()
    {

        gameObject.SetActive(true);
        currentTime = startTime;
        
    }
    void Update()
    {
        //decrement if player has not completed 
        if ((finish_success.COMPLETE == false) && (timeup == false))
        {
            currentTime -= (1 * Time.deltaTime);
            CDtext.text = currentTime.ToString("#.00");
        }    
        
        //on 'esc,' reset variables
        if (Input.GetButton("Cancel"))
        {
            timeup = true;
            gameObject.SetActive(false);    
            SceneManager.LoadScene(0);
            finish_success.COMPLETE = false;
            Audiocontrol.played = false;
            countdowntimer.timeup = false;
            Playerlife.death = false;
            Audiocontrol.index = 0;
            finish.progression = false;
        }
        //when time is up, take me to failure screen
        if (currentTime < 0)
        {
            timeup = true;
            Debug.Log(timeup);
            currentTime = startTime;
            SceneManager.LoadScene("failure");
            gameObject.SetActive(false);

        }

        //when you finish the level, destroy the timer and go to success screen
        if (finish_success.hide == true)
        {
            //gameObject.SetActive(false);
            DestroyObject(gameObject);
        }
    }
}
