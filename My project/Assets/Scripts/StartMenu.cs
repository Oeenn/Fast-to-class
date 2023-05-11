using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private int waitingtime = 1;

    //will be called by the button
    public void Start()
    {
        finish_success.hide = false;
    }
    public void Update()
    {
     
    }

    public void StartGame()
    {
        plswait();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        finish_success.COMPLETE = false;
    }

    IEnumerator plswait()
    {
        yield return new WaitForSecondsRealtime(1);
        
    }
}

