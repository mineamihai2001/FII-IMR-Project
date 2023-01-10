using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightStandConstructor : FurnitureConstructor<NightStandConstructor>
{
    static NightStandConstructor()
    {
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.White), new("Metal", null)));
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.Red), new("Metal", null)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Plastic", ColorEnum.White), new("Metal", null)));
    }
    protected override string GetPath()
    {
        return "Furniture/NightStand/";
    }


    protected override async void Construct()
    {
        var furnitureObject = BePart("nightStand");

        var woodMaterial = await GetMaterial(0);
        var plasticMaterial = await GetMaterial(1);
        var metalMaterial = await GetMaterial(2);

        GameObject cube = FurnitureConstructorUtils.FindChild(furnitureObject, "Cube");
        GameObject cube1 = FurnitureConstructorUtils.FindChild(furnitureObject, "Cube.001");
        GameObject sphere = FurnitureConstructorUtils.FindChild(furnitureObject, "Sphere");


        cube.GetComponent<Renderer>().material = woodMaterial;
        cube1.GetComponent<Renderer>().material = plasticMaterial;
        sphere.GetComponent<Renderer>().material = metalMaterial;
    }
}
