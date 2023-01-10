using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dresser2Constructor : FurnitureConstructor<Dresser2Constructor>
{
    static Dresser2Constructor()
    {
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.Black), new("Metal", null)));
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.White), new("Metal", null)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Plastic", ColorEnum.White), new("Metal", null)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Plastic", ColorEnum.Red), new("Metal", null)));
    }
    protected override string GetPath()
    {
        return "Furniture/Dresser/";
    }


    protected override async void Construct()
    {
        var cabinet = BePart("dresser2");

        var woodMaterial = await GetMaterial(0);
        var plasticMaterial = await GetMaterial(1);
        var metalMaterial = await GetMaterial(2);

        GameObject cube = FurnitureConstructorUtils.FindChild(cabinet, "Cube");
        GameObject drawers = FurnitureConstructorUtils.FindChild(cabinet, "Drawers");
        GameObject top = FurnitureConstructorUtils.FindChild(cabinet, "Top");

        cube.GetComponent<Renderer>().material = woodMaterial;

        Material[] drawersMaterialArray = new Material[] { metalMaterial, plasticMaterial };
        top.GetComponent<Renderer>().materials = drawersMaterialArray;

        Material[] topMaterialArray = new Material[] { plasticMaterial, woodMaterial };
        top.GetComponent<Renderer>().materials = topMaterialArray;

    }
}
