using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointfollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int CurrentWaypointIndex = 0;
    
    private Rigidbody2D rb;
    [SerializeField] private float speed = 24f;

    //teacher size
    private Transform sprite;
    [SerializeField] private float sizex = 3;
    [SerializeField] private float sizey = 3;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<Transform>();
        sprite.transform.localScale = new Vector2(sizex, sizey);
    }
    private void Update()
    {
        //if the distance between the object and the waypoint < 0.1f in the x-values
        if (Vector2.Distance(waypoints[CurrentWaypointIndex].transform.position, transform.position) < 0.001f)
        {
            CurrentWaypointIndex++;
            if (CurrentWaypointIndex >= waypoints.Length)
            {
                CurrentWaypointIndex = 0;
            } 
        }
 
        if (waypoints[CurrentWaypointIndex].transform.position.x > rb.position.x) 
        {
            sprite.transform.localScale = new Vector2(sizex, sizey);
        }
        else if (waypoints[CurrentWaypointIndex].transform.position.x < rb.position.x)
        {
            sprite.transform.localScale = new Vector2(-sizex, sizey);
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[CurrentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
