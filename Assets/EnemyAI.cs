using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path pathM;
    Seeker seeker;
    Rigidbody2D rb;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void onPathComplete(Path p){
        if (!p.error){
            path = p; 
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
