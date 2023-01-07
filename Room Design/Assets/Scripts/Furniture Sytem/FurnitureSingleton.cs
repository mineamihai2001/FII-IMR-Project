using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FurnitureSingleton : MonoBehaviour
{
    public XRRayInteractor ray;
    public InputActionProperty grabButton;
    void Awake()
    {
        ObjectInteractable.floorMask = LayerMask.GetMask("Floor");
        ObjectInteractable.ray = ray;
        ObjectInteractable.grabButton = grabButton;
    }
    static public GameObject getFurnitureByName(string name)
    {
        Debug.Log("GETTING FURNITURE");
        GameObject furniture = new GameObject(name);
        furniture.AddComponent<BoxCollider>();
        furniture.AddComponent<RaleighSofaConstructor>();
        var objInteractableComponent = furniture.AddComponent<ObjectInteractable>();

        objInteractableComponent.ForceGrab();
        

        return furniture;
    }
}
