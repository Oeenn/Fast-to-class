using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private int waitingtime = 1;
    public static bool started = false;
    

    //will be called by the button
    public void Start()
    {
        finish_success.hide = false;
        
        DontDestroyOnLoad(gameObject);
    }
    public void Update()
    {
        
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("tutorial");
    }
    public void StartGame()
    {
        plswait();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        finish_success.COMPLETE = false;
        Invoke("playpregame", 2.5f);
        started = true;
    }

    public void playpregame()
    {
        
    }
    IEnumerator plswait()
    {
        yield return new WaitForSecondsRealtime(1);
        
    }
}

