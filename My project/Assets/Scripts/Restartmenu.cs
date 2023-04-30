using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restartmenu : MonoBehaviour
{
    [SerializeField] private int waitingtime = 1;

    //will be called by the button

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

