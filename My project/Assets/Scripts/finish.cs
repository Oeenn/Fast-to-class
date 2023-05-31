using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class finish : MonoBehaviour
{
    
    public static bool progression = false;
    //public Animator transition;
    [SerializeField] public float time = 0.5f;
    private int count = 0;
    
    public static int cliplength;
    


    private void Update()
    {
        
    }
    void Start()
    {
        
        Debug.Log(Audiocontrol.index);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !progression && count == 0)
        {
            
            Invoke("CompleteLevel", 1f);
            progression = true;
            count = count + 1;
            
            
        }
    }
    public void CompleteLevel()
    {
        //play animation
        //transition.SetTrigger("Start");
        //scenes are ordered in the build manager. Buildindex + 1 loads next scene (level)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

}
