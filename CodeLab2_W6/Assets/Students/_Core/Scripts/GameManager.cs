using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private void Awake()
    {
        if (instance != null & instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

   

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Grid 1");
    }

    public static void Restart()
    {
        CostManager.materialCost.Remove(CostManager.forestMaterial);
        CostManager.materialCost.Remove(CostManager.grassMaterial);
        CostManager.materialCost.Remove(CostManager.lavaMaterial);
        CostManager.materialCost.Remove(CostManager.pathMaterial);
        CostManager.materialCost.Remove(CostManager.rockMaterial);
        CostManager.materialCost.Remove(CostManager.waterMaterial);
        SceneManager.LoadScene("GridInput");
    }
}
