using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk1Constructor : FurnitureConstructor<Desk1Constructor>
{
    static Desk1Constructor()
    {
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.Red), new("Metal", null)));
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.Black), new("Metal", null)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Plastic", ColorEnum.White), new("Metal", null)));
    }
    protected override string GetPath()
    {
        return "Furniture/Desk/";
    }


    protected override async void Construct()
    {
        var furnitureObject = BePart("desk1");

        var woodMaterial = await GetMaterial(0);
        var plasticMaterial = await GetMaterial(1);
        var metalMaterial = await GetMaterial(2);

        GameObject cube = FurnitureConstructorUtils.FindChild(furnitureObject, "Cube");
        GameObject handle1 = FurnitureConstructorUtils.FindChild(furnitureObject, "Cylinder");
        GameObject handle2 = FurnitureConstructorUtils.FindChild(furnitureObject, "Cylinder.001");
        GameObject door = FurnitureConstructorUtils.FindChild(furnitureObject, "Door");
        GameObject drawr = FurnitureConstructorUtils.FindChild(furnitureObject, "Drawr");
        GameObject top1 = FurnitureConstructorUtils.FindChild(furnitureObject, "Top");
        GameObject top2 = FurnitureConstructorUtils.FindChild(furnitureObject, "Top.001");


        cube.GetComponent<Renderer>().material = woodMaterial;
        handle1.GetComponent<Renderer>().material = metalMaterial;
        handle2.GetComponent<Renderer>().material = metalMaterial;
        door.GetComponent<Renderer>().material = woodMaterial;
        drawr.GetComponent<Renderer>().material = woodMaterial;
        top1.GetComponent<Renderer>().material = woodMaterial;
        top2.GetComponent<Renderer>().material = plasticMaterial;
    }
}
