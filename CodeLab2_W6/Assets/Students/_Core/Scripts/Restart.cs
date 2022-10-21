using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField] private Button button;
    //private GameManager gameManager;

    private void Awake()
    {
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    private void OnEnable()
    {
        button.onClick.AddListener(GameManager.Restart);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(GameManager.Restart);
    }


}
