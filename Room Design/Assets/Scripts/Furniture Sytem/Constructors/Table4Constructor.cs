using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table4Constructor : FurnitureConstructor<Table4Constructor>
{
    static Table4Constructor()
    {
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.White)));
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.Black)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Plastic", ColorEnum.Red)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Light Wood", null)));
    }
    protected override string GetPath()
    {
        return "Furniture/Table/";
    }


    protected override async void Construct()
    {
        var furnitureObject = BePart("table4");

        var woodMaterial = await GetMaterial(0);
        var plasticMaterial = await GetMaterial(1);

        Material[] bodyMaterialArray = new Material[] { plasticMaterial, woodMaterial };
        furnitureObject.GetComponent<Renderer>().materials = bodyMaterialArray;
    }
}
