using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk2Constructor : FurnitureConstructor<Desk2Constructor>
{
    static Desk2Constructor()
    {
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.Red), new("Metal", null)));
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.Black), new("Metal", null)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Plastic", ColorEnum.White),new("Metal", null)));
    }
    protected override string GetPath()
    {
        return "Furniture/Desk/";
    }


    protected override async void Construct()
    {
        var furnitureObject = BePart("desk2");

        var woodMaterial = await GetMaterial(0);
        var plasticMaterial = await GetMaterial(1);
        var metalMaterial = await GetMaterial(2);

        GameObject cube = FurnitureConstructorUtils.FindChild(furnitureObject, "Cube");
        GameObject cube1 = FurnitureConstructorUtils.FindChild(furnitureObject, "Cube.001");
        GameObject handle1 = FurnitureConstructorUtils.FindChild(furnitureObject, "Handle");
        GameObject handle2 = FurnitureConstructorUtils.FindChild(furnitureObject, "Handle.001");
        GameObject box = FurnitureConstructorUtils.FindChild(furnitureObject, "Box");

        cube.GetComponent<Renderer>().material = woodMaterial;
        cube1.GetComponent<Renderer>().material = woodMaterial;
        handle1.GetComponent<Renderer>().material = metalMaterial; 
        handle2.GetComponent<Renderer>().material = metalMaterial; 
        box.GetComponent<Renderer>().material = plasticMaterial;
    }
}
