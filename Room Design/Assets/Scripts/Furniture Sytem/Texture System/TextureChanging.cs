using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adobe.Substance;
using Adobe.Substance.Runtime;
using Unity.VisualScripting;

public class TextureChanging : MonoBehaviour
{
    // Start is called before the first frame update
    // public ColorEnum textureColor;
    // public string textureName;
    public SubstanceGraphSO graphSO;
    public ColorEnum color;

    static readonly Dictionary<ColorEnum, Dictionary<string, float>> color_settings = new Dictionary<ColorEnum, Dictionary<string, float>>()
        {
            { ColorEnum.White, new Dictionary<string, float>() {
                    { "color_luminosity", 0.69f},
                }
            },
            { ColorEnum.Black, new Dictionary<string, float>() {
                    { "color_luminosity", 0.35f},
                }
            },
            { ColorEnum.SilverSand, new Dictionary<string, float>() {
                    {"color_luminosity", 0.523f},
                    {"color_hue", 0.274f},
                    {"color_saturation", 0.483f},
                }
            }
        };

    async void recolor()
    {
        //add mySubstance to components
        gameObject.SetActive(false);
        SubstanceRuntimeGraph mySubstance = gameObject.AddComponent<SubstanceRuntimeGraph>();
        //mySubstance.AttachGraph(graphSO);
        mySubstance.GraphSO = graphSO;

        gameObject.SetActive(true);
        foreach (var setting in color_settings[color])
        {
            mySubstance.SetInputFloat(setting.Key, setting.Value);
        }

        var renderTask = mySubstance.RenderAsync();
        await renderTask;
        //change matelial to mySubstance default material
        gameObject.GetComponent<MeshRenderer>().material = new Material(mySubstance.DefaulMaterial);



        Debug.Log("Rendered");
    }
    void Start()
    {
        recolor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
