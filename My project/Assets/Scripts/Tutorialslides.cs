using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorialslides : MonoBehaviour
{
    [SerializeField] public Texture[] imageArray;
    public static int currentImage;


    private void OnGUI()
    {
        //define screen width/height according to screen
        int w = Screen.width, h = Screen.height;
        //make rectangle for image to be 
        Rect imageRect = new Rect(0, 0, w, h);

        GUI.DrawTexture(imageRect, imageArray[currentImage]);

        GUI.Button(new Rect(((w-w/5)-20),(w-w/5),((h-h/5)-20),(h-h/5)), "NEXT");

        if (currentImage >= imageArray.Length)
        {
            currentImage = 0;
        }
        if(currentImage < 0)
        {
            currentImage = imageArray.Length;
        }
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        //move slides forward 
        if (forwardimage.moveforward == true)
        {
            currentImage++;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentImage++;
        }

        if (previmage.moveback == true)
        {
            currentImage--;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentImage--;
        }
    }
}
