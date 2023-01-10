using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetTop2Constructor : FurnitureConstructor<CabinetTop2Constructor>
{
    static CabinetTop2Constructor()
    {
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.Black)));
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.Red)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Plastic", ColorEnum.White)));
    }

    protected override string GetPath()
    {
        return "Furniture/Cabinet/";
    }

    protected override async void Construct()
    {
        var cabinet = BePart("cabinet_top2");

        var woodMaterial = await GetMaterial(0);
        var plasticMaterial = await GetMaterial(1);

        GameObject body = FurnitureConstructorUtils.FindChild(cabinet, "Cabinet");
        GameObject door = FurnitureConstructorUtils.FindChild(cabinet, "Door");
        GameObject handle = FurnitureConstructorUtils.FindChild(cabinet, "Handle");

        body.GetComponent<Renderer>().material = woodMaterial;
        door.GetComponent<Renderer>().material = plasticMaterial;
        handle.GetComponent<Renderer>().material = woodMaterial;
    }
}
