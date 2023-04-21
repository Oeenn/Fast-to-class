using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class countdowntimer : MonoBehaviour
{
    float currentTime = 0;
    float startTime = 60f;

    [SerializeField] public Text CDtext;

    
    void Start()
    {
        
        currentTime = startTime;

    }
    void Update()
    {
        currentTime -= 1*Time.deltaTime;
        CDtext.text = currentTime.ToString();
        


    }
}
