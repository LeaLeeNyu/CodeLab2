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
    private Sprite red;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ballNumber = 0;

        yellow = Resources.Load<Sprite>("Sprites/Yellow");
        blue = Resources.Load<Sprite>("Sprites/Blue");
        red = Resources.Load<Sprite>("Sprites/Red");

        //ballSprites.Add("Blue", blue);
        allBalls.Add(blue);
        spriteRenderer.sprite = allBalls[ballNumber];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(ballNumber == allBalls.Count-1)
            {
                ballNumber = 0;
            }
            else {
                ballNumber++;
            }

            spriteRenderer.sprite = allBalls[ballNumber];
        }       
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
        else if (collision.gameObject.tag == "RedCircle" && !allBalls.Contains(red))
        {
            spriteRenderer.sprite = red;
            allBalls.Add(red);

            GameObject.Destroy(collision.gameObject);
        }

        
    }


}
