using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAcrossScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //save object to next scene
        DontDestroyOnLoad(gameObject);
        Debug.Log(gameObject.scene.name);
    }
}

