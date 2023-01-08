using Adobe.Substance;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class GraphMaterialDynamicTexture
{
    private readonly Dictionary<ColorEnum, Material> materials = new();
    private readonly Dictionary<ColorEnum, Dictionary<string, dynamic>> colorSettings = new();
    private readonly GraphMaterialHandler handler;
    private Dictionary<string, dynamic> defaultSettings = new();
    
    public GraphMaterialDynamicTexture(string graphPath, GameObject gameObject)
    {
        gameObject.SetActive(false);
        handler = gameObject.AddComponent<GraphMaterialHandler>();
        handler.graphSO = Resources.Load<SubstanceGraphSO>(graphPath); //Substance/Leather_graph_0/graph_0
        gameObject.SetActive(true);
    }

    public GraphMaterialDynamicTexture SetDefaultSettings(Dictionary<string, dynamic> defaultSettings)
    {
        this.defaultSettings = defaultSettings;
        return this;
    }

    private Dictionary<string, dynamic> GetSettings(ColorEnum color)
    {
        var settings = new Dictionary<string, dynamic>(defaultSettings);

        if (colorSettings.ContainsKey(color))
        {
            foreach (var setting in colorSettings[color])
            {
                settings[setting.Key] = setting.Value;
            }
        }
        return settings;
    }

    public async Task<Material> GetMaterial(ColorEnum color)
    {
        if (!materials.ContainsKey(color) || materials[color] == null)
            materials[color] = await handler.GetMaterial(GetSettings(color));
        return materials[color];
    }

    public GraphMaterialDynamicTexture AddColor(ColorEnum color, Dictionary<string, dynamic> settings)
    {
        colorSettings[color] = settings;
        return this;
    }
}

public class DynamicTexturingSingleton : MonoBehaviour
{

    private static readonly Dictionary<string, GraphMaterialDynamicTexture> DynamicTextures = new();
    private static readonly Dictionary<string, Material> StaticTextures = new();

    private static GameObject firstGameObject;

    static DynamicTexturingSingleton()
    {
        //var aux = new GameObject("DynamicTexturingSingleton");
        //aux.AddComponent<DynamicTexturingSingleton>();
    }

    private void Init()
    {
        firstGameObject = gameObject;

        var LeatherDynamicMaterial = new GraphMaterialDynamicTexture("Substance/Leather_graph_0/graph_0", gameObject);
        LeatherDynamicMaterial
            .SetDefaultSettings(new() {
                {"color_luminosity", 0.5f},
                {"color_hue", 0.5f},
                {"color_saturation", 0.5f},
            })
            .AddColor(ColorEnum.White, new()
            {
                { "color_luminosity", 0.69f},
            })
            .AddColor(ColorEnum.Black, new()
            { 
                { "color_luminosity", 0.35f},
            })
            .AddColor(ColorEnum.SilverSand, new()
            {
                {"color_luminosity", 0.523f},
                {"color_hue", 0.274f},
                {"color_saturation", 0.483f},
            });

        DynamicTextures["Leather"] = LeatherDynamicMaterial;
        StaticTextures["Dark Wood"] = Resources.Load<Material>("Materials/Dark Wood/Material");
        StaticTextures["Light Wood"] = Resources.Load<Material>("Materials/Light Wood/Material");

    }

    void Awake()
    {
        if (firstGameObject == null)
            Init();
    }

    public static Material GetSimpleMaterial(string name)
    {
        if (!StaticTextures.ContainsKey(name))
        {
            //Debug.Log("No such material: " + name);
            return null;
        }
        return StaticTextures[name];
    }

    public static Task<Material> GetDynamicMaterial(string name, ColorEnum color)
    {
        if (!DynamicTextures.ContainsKey(name))
        {
            //Debug.Log("No such dynamic texture " + name);
            return null;
        }
        return DynamicTextures[name].GetMaterial(color);
    }

}
