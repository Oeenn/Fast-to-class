using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class finish : MonoBehaviour
{
    
    public static bool progression = false;
    //public Animator transition;
    [SerializeField] public float time = 0.5f;
    public static int count = 0;
    [SerializeField] public AudioSource tinkle;

    public static int cliplength;
    


    private void Update()
    {
        
    }
    void Start()
    {
        tinkle = GetComponent<AudioSource>();
        progression = false;
        Debug.Log(Audiocontrol.index);
        count = 0;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !progression && count == 0)
        {
            
            Invoke("CompleteLevel", 1f);
            progression = true;
            count = count + 1;
            tinkle.Play();
            
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
