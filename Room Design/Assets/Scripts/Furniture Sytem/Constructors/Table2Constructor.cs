using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table2Constructor : FurnitureConstructor<Table2Constructor>
{
    static Table2Constructor()
    {
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.Red), new("Metal", null), new("Glass", null)));
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.Black), new("Metal", null), new("Glass", null)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Plastic", ColorEnum.White), new("Metal", null), new("Glass", null)));
    }
    protected override string GetPath()
    {
        return "Furniture/Table/";
    }


    protected override async void Construct()
    {
        var furnitureObject = BePart("table2");

        var woodMaterial = await GetMaterial(0);
        var plasticMaterial = await GetMaterial(1);
        var metalMaterial = await GetMaterial(2);
        var glassMaterial = await GetMaterial(3);

        GameObject top = FurnitureConstructorUtils.FindChild(furnitureObject, "Cube");
        GameObject bottom = FurnitureConstructorUtils.FindChild(furnitureObject, "Cube.001");
        GameObject legs = FurnitureConstructorUtils.FindChild(furnitureObject, "Legs");
        GameObject screw = FurnitureConstructorUtils.FindChild(furnitureObject, "Screw");


        bottom.GetComponent<Renderer>().material = woodMaterial;
        top.GetComponent<Renderer>().material = glassMaterial;
        legs.GetComponent<Renderer>().material = plasticMaterial;
        screw.GetComponent<Renderer>().material = plasticMaterial;

        for (int i=1; i<8; i++)
        {
            var screwName = "Screw.00" + i.ToString();
            GameObject screwNumber = FurnitureConstructorUtils.FindChild(furnitureObject, screwName);
            screwNumber.GetComponent<Renderer>().material = metalMaterial;
        }
    }
}
