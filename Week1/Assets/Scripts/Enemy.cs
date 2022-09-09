using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Transform target;

    public float speed = 200f;
    public float nextWayPointDistance = 3f;

    Path path;
    int currentWayPoint;
    bool reachEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    private void Start()
    {
        //seeker = GetComponent<Seeker>();
        //rb = GetComponent<Rigidbody2D>();

        //InvokeRepeating("PathUpdating", 0, 3f);
    }

    void PathUpdating()
    {
        seeker.StartPath(rb.position, target.position, PathEnd);
    }

    void PathEnd(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    private void FixedUpdate()
    {
        ////make sure there is a path
        //if (path == null)
        //    return; 

        ////if enemy reach the end point of path
        //if(currentWayPoint>= path.vectorPath.Count)
        //{
        //    reachEndOfPath = true;
        //    return;
        //}
        //else
        //{
        //    reachEndOfPath = false;
        //}

        //Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        //Vector2 force = direction * speed ;
        //rb.AddForce(direction);

        //float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        //if(distance< nextWayPointDistance)
        //{
        //    currentWayPoint++;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3 && gameObject.tag == collision.gameObject.tag)
        {
            Destroy(collision.gameObject);
        }else if(collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
