using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SlotButtonHandler : XRSimpleInteractable
{

    public void SelectHandler(SelectEnterEventArgs args)
    {
        var furniture = FurnitureSingleton.getFurnitureByName("Raleigh Sofa");
    }

    void Start()
    {
        selectEntered.AddListener(SelectHandler);
    }
}
