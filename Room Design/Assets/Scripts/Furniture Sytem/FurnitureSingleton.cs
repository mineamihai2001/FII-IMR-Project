using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FurnitureSingleton : MonoBehaviour
{
    public XRRayInteractor ray;
    public InputActionProperty grabButton;
    public ObjectMenuManager menuManager;
    private static Dictionary<string, System.Type> constructors = new(){
        {"Bottom Cabinet", typeof(CabinetBottomConstructor)},
        {"Raleigh Sofa", typeof(RaleighSofaConstructor)}
    };

    void Awake()
    {
        ObjectInteractable.floorMask = LayerMask.GetMask("Floor");
        ObjectInteractable.ray = ray;
        ObjectInteractable.grabButton = grabButton;
        ObjectInteractable.menuManager = menuManager;
    }
    static public GameObject GetFurnitureByName(string name)
    {
        Debug.Log("GETTING FURNITURE");
        GameObject furniture = new GameObject(name);
        //var sofaConstructorComponent = furniture.AddComponent<RaleighSofaConstructor>();
        furniture.AddComponent(constructors[name]);
        var objInteractableComponent = furniture.AddComponent<ObjectInteractable>();

        objInteractableComponent.ForceGrab();


        return furniture;
    }
}
