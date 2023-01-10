using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class IFurnitureContructor : MonoBehaviour
{
    abstract public void SetParameter(string parameterName, int value);

    abstract public FurnitureParameter GetParameter(string parameterName);

    abstract public void Reconstruct();
}
