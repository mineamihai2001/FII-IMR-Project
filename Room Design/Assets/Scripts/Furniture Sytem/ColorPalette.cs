using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ColorPalette
{
    private readonly List<Tuple<String, ColorEnum?>> colors = new();

    //public ColorPalette(List<List<dynamic>> colors)
    //{
    //    foreach(var color in colors)
    //    {
    //        var name = color[0];
    //        //if color type is not string throw exception
    //        if (name.GetType() != typeof(string))
    //            throw new Exception("Color[0] type is not string");

    //        if (colors.Count == 1)
    //            this.colors.Add(new(name, null));
    //        else
    //        {
    //            var colorValue = color[1];
    //            //if color type is not string throw exception
    //            if (colorValue.GetType() != typeof(ColorEnum))
    //                throw new Exception("Color[1] type is not Color");

    //            this.colors.Add(new(name, colorValue));
    //        }
    //    }
    //}

    public ColorPalette(List<Tuple<String, ColorEnum?>> colors)
    {
        this.colors = colors;
    }

    //constructor with infinite parameters
    public ColorPalette(params Tuple<String, ColorEnum?>[] colors)
    {
        this.colors = new List<Tuple<String, ColorEnum?>>(colors);
    }

    public int Count => colors.Count;

    public async Task<Material> GetMaterial(int index)
    {
        var color = colors[index];

        if (color.Item2 != null)
            return await DynamicTexturingSingleton.GetDynamicMaterial(color.Item1, color.Item2 ?? ColorEnum.White);
        
        return DynamicTexturingSingleton.GetSimpleMaterial(color.Item1);
    }
}
