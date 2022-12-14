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

    public BoxCollider2D[] greens;
    public BoxCollider2D[] blues;
    public BoxCollider2D[] yellows;

    public List<BoxCollider2D> greensList;
    public List<BoxCollider2D> bluesList;
    public List<BoxCollider2D> yellowsList;  

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

        AddtoList(greens, greensList);
        AddtoList(blues, bluesList);
        AddtoList(yellows, yellowsList);

        TriggerTure(bluesList);
    }

    void AddtoList(BoxCollider2D[] cols,List<BoxCollider2D> list)
    {
        foreach(BoxCollider2D col in cols)
        {
            if (col == null)
                break;

            list.Add(col);
        }
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

            TriggerTure(yellowsList);
            TriggerFalse(bluesList);
            TriggerFalse(greensList);
        }
        else if(collision.gameObject.tag == "BlueCircle" && !allBalls.Contains(blue))
        {
            spriteRenderer.sprite = blue;
            gameObject.tag = "Blue";
            allBalls.Add(blue);

            GameObject.Destroy(collision.gameObject);

            TriggerTure(bluesList);
            TriggerFalse(yellowsList);
            TriggerFalse(greensList);
        }
        else if (collision.gameObject.tag == "GreenCircle" && !allBalls.Contains(green))
        {
            spriteRenderer.sprite = green;
            gameObject.tag = "Green";
            allBalls.Add(green);

            GameObject.Destroy(collision.gameObject);

            TriggerTure(greensList);
            TriggerFalse(yellowsList);
            TriggerFalse(bluesList);
        }

        
    }

    void TriggerTure(List<BoxCollider2D> colors)
    {
        foreach (BoxCollider2D color in colors)
        {
            color.isTrigger = true;
        }
    }

    void TriggerFalse (List<BoxCollider2D> colors)
    {
        foreach (BoxCollider2D color in colors)
        {
            color.isTrigger = false;
        }
    }

    public void RemovefromList(BoxCollider2D col)
    {
        if(col.gameObject.tag == "Yellow")
        {
            yellowsList.Remove(col);
        }
        else if (col.gameObject.tag == "Blue")
        {
            bluesList.Remove(col);
        }
        else if (col.gameObject.tag == "Green")
        {
            greensList.Remove(col);
        }
    }


}
