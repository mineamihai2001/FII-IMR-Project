using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table3Constructor : FurnitureConstructor<Table3Constructor>
{
    static Table3Constructor()
    {
        colorPaletteList.Add(new(new("Light Wood", null), new("Glass", null)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Glass", null)));
    }
    protected override string GetPath()
    {
        return "Furniture/Table/";
    }


    protected override async void Construct()
    {
        var furnitureObject = BePart("table3");

        var woodMaterial = await GetMaterial(0);
        var glassMaterial = await GetMaterial(1);


        GameObject top = FurnitureConstructorUtils.FindChild(furnitureObject, "Top");
        GameObject legs = FurnitureConstructorUtils.FindChild(furnitureObject, "Legs_v1");

        top.GetComponent<Renderer>().material = woodMaterial;
        legs.GetComponent<Renderer>().material = glassMaterial;
    }
}
