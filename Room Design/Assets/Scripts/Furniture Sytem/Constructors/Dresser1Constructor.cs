using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dresser1Constructor : FurnitureConstructor<Dresser1Constructor>
{
    static Dresser1Constructor()
    {
        colorPaletteList.Add(new(new("Light Wood", null), new("Light Wood", null)));
        colorPaletteList.Add(new(new("Light Wood", null), new("Dark Wood", null)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Dark Wood", null)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Light Wood", null)));
    }
    protected override string GetPath()
    {
        return "Furniture/Dresser/";
    }

    protected override async void Construct()
    {
        var furnitureObject = BePart("dresser1");

        var woodMaterial = await GetMaterial(0);

        Material[] bodyMaterialArray = new Material[] { woodMaterial, woodMaterial };
        furnitureObject.GetComponent<Renderer>().materials = bodyMaterialArray;
    }
}
