using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkConstructor : FurnitureConstructor<SinkConstructor>
{
    static SinkConstructor()
    {
        colorPaletteList.Add(new(new("Marble", ColorEnum.Black), new("Marble", ColorEnum.White)));
        colorPaletteList.Add(new(new("Marble", ColorEnum.White), new("Marble", ColorEnum.White)));
        colorPaletteList.Add(new(new("Marble", ColorEnum.Black), new("Marble", ColorEnum.Black)));
    }
    protected override string GetPath()
    {
        return "Furniture/Sink/";
    }

    protected override async void Construct()
    {
        var sink = BePart("sink");

        var marbleMaterial = await GetMaterial(0);

        GameObject body = FurnitureConstructorUtils.FindChild(sink, "Sink");
        GameObject tap = FurnitureConstructorUtils.FindChild(sink, "MainTap");
        GameObject tapHandle = FurnitureConstructorUtils.FindChild(tap, "TapHandle");

        body.GetComponent<Renderer>().material = marbleMaterial;
        tap.GetComponent<Renderer>().material = marbleMaterial;
        tapHandle.GetComponent<Renderer>().material = marbleMaterial;
    }
}
