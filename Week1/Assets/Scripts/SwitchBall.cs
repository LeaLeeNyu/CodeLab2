using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SwitchBall : MonoBehaviour
{
    public List<Sprite> allBalls;
    private int ballNumber = 0;
    private SpriteRenderer spriteRenderer;

    private Sprite yellow;
    private Sprite blue;
    private Sprite green;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ballNumber = 0;

        yellow = Resources.Load<Sprite>("Sprites/Yellow");
        blue = Resources.Load<Sprite>("Sprites/Blue");
        green = Resources.Load<Sprite>("Sprites/Green");
     
        allBalls.Add(blue);
        spriteRenderer.sprite = allBalls[ballNumber];
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "YellowCircle" && !allBalls.Contains(yellow))
        {
            spriteRenderer.sprite = yellow;
            allBalls.Add(yellow);

            GameObject.Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "BlueCircle" && !allBalls.Contains(blue))
        {
            spriteRenderer.sprite = blue;
            allBalls.Add(blue);

            GameObject.Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "GreenCircle" && !allBalls.Contains(green))
        {
            spriteRenderer.sprite = green;
            allBalls.Add(green);

            GameObject.Destroy(collision.gameObject);
        }

        
    }


}
