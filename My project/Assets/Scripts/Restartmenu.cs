using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restartmenu : MonoBehaviour
{

    //will be called by the button
    //reset variables
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        finish_success.COMPLETE =false;
        Audiocontrol.played = false;
        countdowntimer.timeup = false;
        Playerlife.death = false;
        Audiocontrol.index = 0;
        finish.progression = false;
    }
}

