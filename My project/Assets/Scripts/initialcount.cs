using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class initialcount : MonoBehaviour
{
    public static float currentTime = 0;
    float startTime = 60;

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
