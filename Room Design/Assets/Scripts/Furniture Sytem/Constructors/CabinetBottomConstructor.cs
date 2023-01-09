using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetBottomConstructor : FurnitureConstructor<CabinetBottomConstructor>
{
    static CabinetBottomConstructor()
    {
        colorPaletteList.Add(new(new("Light Wood", null), new("Leather", ColorEnum.Black)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Leather", ColorEnum.SilverSand)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Leather", ColorEnum.White)));
    }
    protected override string GetPath()
    {
        return "Furniture/Cabinet/";
    }


    protected override void Construct()
    {
        var cabinet = BePart("cabinet_bottom");
    }

}
