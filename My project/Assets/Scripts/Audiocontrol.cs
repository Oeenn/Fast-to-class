using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiocontrol : MonoBehaviour
{
    
    [SerializeField] AudioClip[] successsounds;
    [SerializeField] AudioClip[] pregameclip;
    [SerializeField] AudioClip[] failuresound;
    [SerializeField] AudioClip[] deathclips;



    AudioSource myaudioclip;
    public static bool played = false;
    // Start is called before the first frame update
    void Start()
    {
        myaudioclip = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
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

        //if (Playerlife.death == true)
        //{
        //    deathsound();
        //}

        if (StartMenu.started == true)
        {
            playpregame();
            StartMenu.started = false;
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
        //void deathsound()
        //{
        //    AudioClip death = deathclips[UnityEngine.Random.Range(0, deathclips.Length)];
          //  myaudioclip.PlayOneShot(death);
        //}
    }
}
