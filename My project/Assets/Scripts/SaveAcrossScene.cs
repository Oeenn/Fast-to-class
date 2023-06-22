using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAcrossScene : MonoBehaviour
{    void Start()
    {
        //save object to next scene
        DontDestroyOnLoad(gameObject);
        Debug.Log(gameObject.scene.name);
    }
}

