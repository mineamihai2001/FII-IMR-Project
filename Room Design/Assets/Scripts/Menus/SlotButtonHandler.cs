using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SlotButtonHandler : XRSimpleInteractable
{
    public string furnitureName;

    public void SelectHandler(SelectEnterEventArgs args)
    {
        var furniture = FurnitureSingleton.GetFurnitureByName(furnitureName);
    }

    void Start()
    {
        selectEntered.AddListener(SelectHandler);
    }
}
