using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private int waitingtime = 1;
    public static bool started = false;
    [SerializeField] private AudioSource sound;
    //will be called by the button
    public void Start()
    {
        finish_success.hide = false;
        sound = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
    public void Update()
    {
        
    }

    //tutorial and start game buttons are on the main menu, both should be functions
    public void Tutorial()
    {
        SceneManager.LoadScene("tutorial");
        sound.Play();
    }
    public void StartGame()
    {
        plswait();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        finish_success.COMPLETE = false;
        Invoke("playpregame", 2.5f);
        started = true;
        sound.Play();
    }

    //not used
    public void playpregame()
    {
        
    }
    //not used
    IEnumerator plswait()
    {
        yield return new WaitForSecondsRealtime(1);
        
    }
}

