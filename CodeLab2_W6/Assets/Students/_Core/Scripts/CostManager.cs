using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CostManager : MonoBehaviour
{
    static public Dictionary<Material, float> materialCost = new Dictionary<Material, float>();

    float forest=0;
    float grass=0;
    float lava = 0;
    float path = 0;
    float rock = 0;
    float water = 0;

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

    public static Material forestMaterial;
    public static Material grassMaterial;
    public static Material lavaMaterial;
    public static Material pathMaterial;
    public static Material rockMaterial;
    public static Material waterMaterial;
    public Material forestM;
    public Material grassM;
    public Material lavaM;
    public Material pathM;
    public Material rockM;
    public Material waterM;

    private void Start()
    {
        forestMaterial = forestM;
        grassMaterial = grassM;
        lavaMaterial = lavaM;
        pathMaterial = pathM;
        rockMaterial = rockM;
        waterMaterial = waterM;

        materialCost.Add(forestMaterial, forest);
        materialCost.Add(grassMaterial, grass);
        materialCost.Add(lavaMaterial, lava);
        materialCost.Add(pathMaterial, path);
        materialCost.Add(rockMaterial, rock);
        materialCost.Add(waterMaterial, water);
    }

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
        materialCost[forestMaterial] = forest;
        materialCost[grassMaterial] = grass;
        materialCost[lavaMaterial] = lava;
        materialCost[pathMaterial] = path;
        materialCost[rockMaterial] = rock;
        materialCost[waterMaterial] = water;
    }
}
