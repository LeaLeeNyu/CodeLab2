using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowFence : MonoBehaviour
{
    //private Sprite yellow;
    private BoxCollider2D boxCollider;    


    private void Start()
    {
        //yellow = Resources.Load<Sprite>("Sprites/Yellow");
        boxCollider = GetComponent<BoxCollider2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Sprite playerSprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
        if(playerSprite.name == gameObject.tag)
        {
            boxCollider.isTrigger = true;
        }
        else
        {
            boxCollider.isTrigger = false;
        }
    }
}
