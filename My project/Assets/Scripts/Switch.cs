using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    public GameObject[] images;
    private int index = 0;
 
    void Start()
    {
        Debug.Log(images.Length);
        index = 0;
        for (int i = 0; i <= images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
            images[index].gameObject.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene(0);
        }
        //if (index == 0) 
        {
            //images[0].gameObject.SetActive(true);

        }


    }
    public void Next()
    {
        index+= 1;
        Debug.Log(index);
        if (index >= images.Length)
        {
            index = 0;
        }
        Debug.Log(index);
        for (int i = 0; i<= images.Length; i++)
        {
            
            images[i].gameObject.SetActive(false);
            images[index].gameObject.SetActive(true);
            if (i == images.Length)
            {
                images[0].gameObject.SetActive(true);
            }
        }
        
    }

    public void Prev()
    {
        index-= 1;
        if (index < 0)
        {
            index = images.Length;
        }

        for (int i = images.Length; i >= 0; i--)
        {
            images[i].gameObject.SetActive(false);
            images[index].gameObject.SetActive(true);
            
        }
        Debug.Log(index);
    }

}
