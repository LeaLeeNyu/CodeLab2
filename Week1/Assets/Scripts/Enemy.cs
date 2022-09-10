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

    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3 && gameObject.tag == collision.gameObject.tag)
        {
            player.GetComponent<SwitchBall>().RemovefromList(collision.gameObject.GetComponent<BoxCollider2D>());
            Destroy(collision.gameObject);

        }else if(collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
