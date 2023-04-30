using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teachersize : MonoBehaviour
{
    [SerializeField] private float sizex = 3;
    [SerializeField] private float sizey = 3;
    private Transform sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<Transform>();
        sprite.transform.localScale = new Vector2(sizex, sizey);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
