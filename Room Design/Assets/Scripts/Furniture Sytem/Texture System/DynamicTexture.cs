using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTexture : MonoBehaviour
{
    public ColorEnum color;
    // Start is called before the first frame update
    
    public async void changeColor(ColorEnum toColor)
    {
        //Debug.Log("Changing color + " + toColor);
        GetComponent<Renderer>().material = await DynamicTexturingSingleton.GetDynamicMaterial("Leather", toColor);
    }
    void Start()
    {
        changeColor(color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
