using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFurniturePalette : MonoBehaviour
{
    public int colorPaletteIndex = 0;
    private int oldColorPaletteIndex = 0;

    private void Update()
    {
        if (colorPaletteIndex != oldColorPaletteIndex)
        {
            Debug.Log("Color Palette Index Changed");
            FurnitureConstructor<dynamic> furnitureConstructor = gameObject.GetComponent<FurnitureConstructor<dynamic>>();
            if (furnitureConstructor != null)
            {
                furnitureConstructor.SetParameter("Color Palette Index", colorPaletteIndex);
                furnitureConstructor.Reconstruct();
            }
            oldColorPaletteIndex = colorPaletteIndex;
        }
    }
}
