using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletConstructor : FurnitureConstructor<ToiletConstructor>
{
    static ToiletConstructor()
    {
        colorPaletteList.Add(new(new("Marble", ColorEnum.Black), new("Marble", ColorEnum.White)));
        colorPaletteList.Add(new(new("Marble", ColorEnum.White), new("Marble", ColorEnum.White)));
        colorPaletteList.Add(new(new("Marble", ColorEnum.Black), new("Marble", ColorEnum.Black)));
    }
    protected override string GetPath()
    {
        return "Furniture/Toilet/";
    }

    protected override async void Construct()
    {
        var furnitureObject = BePart("toilet");

        var marbleMaterial = await GetMaterial(0);

        GameObject cylinder = FurnitureConstructorUtils.FindChild(furnitureObject, "Cylinder");
        GameObject lid = FurnitureConstructorUtils.FindChild(furnitureObject, "TankLid");
        GameObject bottom = FurnitureConstructorUtils.FindChild(furnitureObject, "ToiletBottom");
        GameObject bowl = FurnitureConstructorUtils.FindChild(bottom, "Bowl");
        GameObject seat = FurnitureConstructorUtils.FindChild(furnitureObject, "ToiletSeat");
        GameObject seatLid = FurnitureConstructorUtils.FindChild(seat, "ToiletSeatLid");

        cylinder.GetComponent<Renderer>().material = marbleMaterial;
        lid.GetComponent<Renderer>().material = marbleMaterial;
        bottom.GetComponent<Renderer>().material = marbleMaterial;
        bowl.GetComponent<Renderer>().material = marbleMaterial;
        seat.GetComponent<Renderer>().material = marbleMaterial;
        seatLid.GetComponent<Renderer>().material = marbleMaterial;
    }
}
