using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureConstructorUtils
{
    static public GameObject FindChild(GameObject parent, string name)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == name)
            {
                return child.gameObject;
            }
        }
        return null;
    }
}
