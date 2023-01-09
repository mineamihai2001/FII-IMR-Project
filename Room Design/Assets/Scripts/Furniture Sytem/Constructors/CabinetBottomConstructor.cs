using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetBottomConstructor : FurnitureConstructor<CabinetBottomConstructor>
{
    static CabinetBottomConstructor()
    {
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.Black)));
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.White)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Plastic", ColorEnum.White)));
    }
    protected override string GetPath()
    {
        return "Furniture/Cabinet/";
    }


    protected override async void Construct()
    {
        var cabinet = BePart("cabinet_bottom");

        var woodMaterial = await GetMaterial(0);
        var plasticMaterial = await GetMaterial(1);

        GameObject body = FurnitureConstructorUtils.FindChild(cabinet, "Cabinet");
        GameObject top = FurnitureConstructorUtils.FindChild(cabinet, "Cabinet.001");
        GameObject door = FurnitureConstructorUtils.FindChild(cabinet, "Door");
        GameObject handle = FurnitureConstructorUtils.FindChild(cabinet, "Handle");

        Material[] bodyMaterialArray = new Material[] { plasticMaterial, woodMaterial };
        body.GetComponent<Renderer>().materials = bodyMaterialArray;

        top.GetComponent<Renderer>().material = woodMaterial;
        door.GetComponent<Renderer>().material = plasticMaterial;
        handle.GetComponent<Renderer>().material = plasticMaterial;
    }

}
