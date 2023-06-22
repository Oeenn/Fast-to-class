using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audiocontrol : MonoBehaviour
{
    //define all folders
    [SerializeField] AudioClip[] successsounds;
    [SerializeField] AudioClip[] pregameclip;
    [SerializeField] AudioClip[] failuresound;
    [SerializeField] AudioClip[] deathclips;
    [SerializeField] AudioClip[] finishsound;
    public static int index = 1;


    AudioSource myaudioclip;
    public static bool played = false;
    public static bool midgame = false;
    // Start is called before the first frame update
    void Start()
    {
        myaudioclip = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(true);
        
    }

    
    void Update()
    {
        // casewhere for different sounds, with bools to indicate that it has been played (and will not play continously)
        if ((finish_success.COMPLETE == true) && played == false)
        {
            playsuccess();
            played = true;
        }

        if ((countdowntimer.timeup == true) && played == false)
        {
            playfail();
            played = true;
        }

        if(finish.progression == true)
        {
            progress();
            index++;
            finish.progression = false;
        }
        if (index > finishsound.Length)
        {
            index = 0;
        }
        
        if (StartMenu.started == true)
        {
            playpregame();
            StartMenu.started = false;
        }

        void progress()
        {
            AudioClip progression = finishsound[index - 1];
            myaudioclip.PlayOneShot(progression);
        }
        void playsuccess()
        {
            AudioClip success = successsounds[UnityEngine.Random.Range(0, successsounds.Length)];
            myaudioclip.PlayOneShot(success);
        }
        void playfail()
        {
            AudioClip fail = failuresound[UnityEngine.Random.Range(0, failuresound.Length)];
            myaudioclip.PlayOneShot(fail);
        }
        void playpregame()
        {
            AudioClip pregame = pregameclip[UnityEngine.Random.Range(0, pregameclip.Length)];
            myaudioclip.PlayOneShot(pregame);
        }

        
       
    }
}
