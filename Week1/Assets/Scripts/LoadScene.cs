using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    int loadSceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {


            if (collision.gameObject.name == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                loadSceneIndex = 1;
            }
            else
            {
                loadSceneIndex = 0;
            }
            SceneManager.LoadScene(loadSceneIndex);
        }
            
    }

    public void ReLoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
