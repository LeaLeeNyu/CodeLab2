using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    public GameObject[] fences;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if collision gameobject have same color with fence
        if(collision.gameObject.tag == gameObject.tag)
        {
            //if collision gameobject is enemy
            if(collision.gameObject.layer == 6)
            {
                Destroy(gameObject);
                foreach(GameObject fence in fences)
                {
                    Destroy(fence);
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
                
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Exit");
        gameObject.SetActive(true);

    }
}
