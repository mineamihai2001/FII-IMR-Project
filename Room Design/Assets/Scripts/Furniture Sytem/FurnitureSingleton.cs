using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureSingleton : MonoBehaviour
{
    static public GameObject getFurnitureByName(string name)
    {
        GameObject furniture = new GameObject(name);
        furniture.AddComponent<RaleighSofaConstructor>();

        return furniture;
    }
}
