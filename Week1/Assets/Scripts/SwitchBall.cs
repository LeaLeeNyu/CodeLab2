using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SwitchBall : MonoBehaviour
{
    //I first use list to store balls' sprite, because at first the gameplay is use space button to switch ball's color
    public List<Sprite> allBalls;
    private int ballNumber = 0;
    private SpriteRenderer spriteRenderer;

    private Sprite yellow;
    private Sprite blue;
    private Sprite green;

    public BoxCollider2D[] grenns;
    public BoxCollider2D[] blues;
    public BoxCollider2D[] yellows;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ballNumber = 0;

        yellow = Resources.Load<Sprite>("Sprites/Yellow");
        blue = Resources.Load<Sprite>("Sprites/Blue");
        green = Resources.Load<Sprite>("Sprites/Green");
     
        allBalls.Add(blue);
        gameObject.tag = "Blue";
        spriteRenderer.sprite = allBalls[ballNumber];

        TriggerTure(blues);
    }

    //Swith player's color
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "YellowCircle" && !allBalls.Contains(yellow))
        {
            spriteRenderer.sprite = yellow;
            gameObject.tag = "Yellow";
            allBalls.Add(yellow);

            GameObject.Destroy(collision.gameObject);

            TriggerTure(yellows);
            TriggerFalse(blues);
            TriggerFalse(grenns);
        }
        else if(collision.gameObject.tag == "BlueCircle" && !allBalls.Contains(blue))
        {
            spriteRenderer.sprite = blue;
            gameObject.tag = "Blue";
            allBalls.Add(blue);

            GameObject.Destroy(collision.gameObject);

            TriggerTure(blues);
            TriggerFalse(yellows);
            TriggerFalse(grenns);
        }
        else if (collision.gameObject.tag == "GreenCircle" && !allBalls.Contains(green))
        {
            spriteRenderer.sprite = green;
            gameObject.tag = "Green";
            allBalls.Add(green);

            GameObject.Destroy(collision.gameObject);

            TriggerTure(grenns);
            TriggerFalse(yellows);
            TriggerFalse(blues);
        }

        
    }

    void TriggerTure(BoxCollider2D[] colors)
    {
        foreach (BoxCollider2D color in colors)
        {
            color.isTrigger = true;
        }
    }

    void TriggerFalse (BoxCollider2D[] colors)
    {
        foreach (BoxCollider2D color in colors)
        {
            color.isTrigger = false;
        }
    }


}
