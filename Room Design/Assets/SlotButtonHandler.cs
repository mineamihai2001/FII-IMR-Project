using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotButtonHandler : MonoBehaviour
{
    
    public void getFurniture(string name)
    {
        Debug.Log("CLICKED");
        GameObject furniture = FurnitureSingleton.getFurnitureByName(name);
        furniture.transform.position = new Vector3(0, 0, 0);
    }
}
