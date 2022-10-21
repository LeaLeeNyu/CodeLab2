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

    static public Dictionary<Material, float> materialCost = new Dictionary<Material, float>();

    float forest;
    float grass;
    float lava;
    float path;
    float rock;
    float water;

    [SerializeField] private Slider forestSlider;
    [SerializeField] private Slider grassSlider;
    [SerializeField] private Slider lavaSlider;
    [SerializeField] private Slider pathSlider;
    [SerializeField] private Slider rockSlider;
    [SerializeField] private Slider waterSlider;

    [SerializeField] private TMP_Text forestText;
    [SerializeField] private TMP_Text grassText;
    [SerializeField] private TMP_Text lavaText;
    [SerializeField] private TMP_Text pathText;
    [SerializeField] private TMP_Text rockText;
    [SerializeField] private TMP_Text waterText;

    [SerializeField] private Material forestMaterial;
    [SerializeField] private Material grassMaterial;
    [SerializeField] private Material lavaMaterial;
    [SerializeField] private Material pathMaterial;
    [SerializeField] private Material rockMaterial;
    [SerializeField] private Material waterMaterial;


    void Update()
    {
        forest = (float)System.Math.Round(forestSlider.value * 100, 2);
        grass = (float)System.Math.Round(grassSlider.value * 100, 2);
        lava = (float)System.Math.Round(lavaSlider.value * 100, 2);
        path = (float)System.Math.Round(pathSlider.value * 100, 2);
        rock = (float)System.Math.Round(rockSlider.value * 100, 2);
        water = (float)System.Math.Round(waterSlider.value * 100, 2);

        forestText.text = forest.ToString();
        grassText.text = grass.ToString();
        lavaText.text = lava.ToString();
        pathText.text = path.ToString();
        rockText.text = rock.ToString();
        waterText.text = water.ToString();
    }

    public void AddCost()
    {
        materialCost.Add(forestMaterial,forest);
        materialCost.Add(grassMaterial,grass);
        materialCost.Add(lavaMaterial,lava);
        materialCost.Add(pathMaterial,path);
        materialCost.Add(rockMaterial,rock);
        materialCost.Add(waterMaterial,water);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Grid 1");
    }
}
