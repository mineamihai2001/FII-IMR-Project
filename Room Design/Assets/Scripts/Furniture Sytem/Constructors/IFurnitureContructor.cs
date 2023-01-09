using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFurnitureContructor : MonoBehaviour
{
    public virtual void SetParameter(string parameterName, int value)
    {
        Debug.LogError("SetParameter not implemented");
    }

    public virtual void Reconstruct()
    {
        Debug.LogError("Reconstruct not implemented");
    }
}
