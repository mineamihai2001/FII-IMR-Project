using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMaterial : MonoBehaviour
{
    public string materialName;
    public ColorEnum materialColor;

    private async void AddMaterial()
    {
        Material mat = await DynamicTexturingSingleton.GetDynamicMaterial(materialName, materialColor);
        gameObject.GetComponent<Renderer>().material = mat;
    } 
    
    void Start()
    {
        AddMaterial();
        ColorEnum
    }
}
