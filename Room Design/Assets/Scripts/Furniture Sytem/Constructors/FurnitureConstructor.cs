using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class FurnitureParameter
{
    private int _value;
    public int Value
    {
        get => _value;
        set {
            if (value < MinValue)
                _value = MinValue;
            else if (value > MaxValue)
                _value = MaxValue;
            else
                _value = value;
        }
    }
    public int MinValue { get;}
    public int MaxValue { get;}

    public FurnitureParameter(int value, int minValue, int maxValue)
    {
        MinValue = minValue;
        MaxValue = maxValue;
        Value = value;
    }
}

//missing furniture parameter custom exception
public class FurnitureParameterNotFoundException : Exception
{
    public FurnitureParameterNotFoundException(string parameterName) : base("Furniture parameter " + parameterName + " not found")
    {
    }
}


public abstract class FurnitureConstructor<T> : MonoBehaviour where T : class
{
    protected readonly Dictionary<string, FurnitureParameter> parameters = new();
    //private readonly List<GameObject> gameObjects = new();
    protected static readonly List<ColorPalette> colorPaletteList = new();

    abstract protected string GetPath();
    
    protected GameObject GetPart(string name)
    {
        string objectPath = GetPath() + name;
        GameObject rv = Resources.Load<GameObject>(objectPath);
        GameObject instance = Instantiate(rv);
        instance.transform.parent = gameObject.transform;
        instance.transform.position = gameObject.transform.position;
        //gameObjects.Add(instance);

        return instance;
    }

    protected virtual void Awake()
    {
        parameters.Add("Color Palette Index", new FurnitureParameter(0, 0, colorPaletteList.Count - 1));
    }

    public void SetParameter(string parameterName, int value)
    {
        if (!parameters.ContainsKey(parameterName))
            throw new FurnitureParameterNotFoundException(parameterName);
        parameters[parameterName].Value = value;
    }

    abstract protected void Construct();

    public void Reconstruct()
    {
        //destroy each child
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Construct();
    }
        
    public void Start()
    {
        //TODO: this should be "Construct" after done testing
        Reconstruct();
    }


    protected Task<Material> getMaterial(int index)
    {
        var collorPalleteIndex = parameters["Color Palette Index"].Value;
        return colorPaletteList[collorPalleteIndex].GetMaterial(index);
    }
}

