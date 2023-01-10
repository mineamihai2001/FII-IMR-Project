using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachineConstructor : FurnitureConstructor<WashingMachineConstructor>
{
    static WashingMachineConstructor()
    {
        colorPaletteList.Add(new(new("Marble", ColorEnum.Black), new("Marble", ColorEnum.White)));
        colorPaletteList.Add(new(new("Marble", ColorEnum.White), new("Marble", ColorEnum.White)));
    }
    protected override string GetPath()
    {
        return "Furniture/WashingMachine/";
    }

    protected override async void Construct()
    {
        var furnitureObject = BePart("washing_machine");

        var marbleMaterial = await GetMaterial(0);

        Material[] bodyMaterialArray = new Material[] { marbleMaterial, marbleMaterial, marbleMaterial };
        furnitureObject.GetComponent<Renderer>().materials = bodyMaterialArray;
    }
}
