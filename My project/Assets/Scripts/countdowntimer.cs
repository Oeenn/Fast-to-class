using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class countdowntimer : MonoBehaviour
{
    float currentTime = 0;
    [SerializeField] float startTime = 60f;
    private bool timeup = false;
    [SerializeField] public Text CDtext;

    
    void Start()
    {
        
        currentTime = startTime;

    }
    void Update()
    {
        currentTime -= (1 * Time.deltaTime);
        CDtext.text = currentTime.ToString("#.00");

        if (currentTime < 0)
        {
            timeup = true;
            Debug.Log(timeup);
            SceneManager.LoadScene(-1);

        }
    }
}
