using UnityEngine;

public class Table1Constructor : FurnitureConstructor<Table1Constructor>
{
    static Table1Constructor()
    {
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.White)));
        colorPaletteList.Add(new(new("Light Wood", null), new("Plastic", ColorEnum.Black)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Plastic", ColorEnum.White)));
    }
    protected override string GetPath()
    {
        return "Furniture/Table/";
    }


    protected override async void Construct()
    {
        var furnitureObject = BePart("table1");

        var woodMaterial = await GetMaterial(0);
        var plasticMaterial = await GetMaterial(1);

        GameObject bottom = FurnitureConstructorUtils.FindChild(furnitureObject, "Cube.001");
        GameObject top = FurnitureConstructorUtils.FindChild(furnitureObject, "Cube.005");
        GameObject legs = FurnitureConstructorUtils.FindChild(furnitureObject, "Legs");

        bottom.GetComponent<Renderer>().material = woodMaterial;
        top.GetComponent<Renderer>().material = woodMaterial;
        legs.GetComponent<Renderer>().material = plasticMaterial;
    }
}
