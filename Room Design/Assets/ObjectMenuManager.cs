using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectMenuManager : MonoBehaviour
{
    public InputActionProperty showButton;
    public GameObject menu;
    public GameObject objectToEdit;
    public Camera mainCamera;
    void Awake()
    {
        menu.SetActive(false);
    }

    private void Update()
    {
        if (objectToEdit != null)
        {
            if(!menu.activeSelf)
                menu.SetActive(true);
            menu.transform.position = (mainCamera.transform.position + objectToEdit.transform.position) / 2;
            menu.transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward, mainCamera.transform.up);
        }
        else if (menu.activeSelf)
            menu.SetActive(false);

        //if (menu.activeSelf)
        //{
        //    menu.transform.position = (mainCamera.transform.position + objectToEdit.transform.position) / 2;
        //}
    }

    public void IncrementParameter(string name)
    {
        Debug.Log("Incrementing " + name);
        IFurnitureContructor furnitureContructor = objectToEdit.GetComponent<IFurnitureContructor>();

        if (furnitureContructor != null)
        {
            FurnitureParameter param = furnitureContructor.GetParameter(name);
            if (param != null)
            {
                int value = param.Value;
                if (value == param.MaxValue)
                    value = param.MinValue;
                else
                    value++;

                furnitureContructor.SetParameter(name, value);
                furnitureContructor.Reconstruct();
                
            }
        }
    }

    public void HandleGrab()
    {
        if (objectToEdit != null)
        {
            ObjectInteractable objInteractable = objectToEdit.GetComponent<ObjectInteractable>();
            if (objInteractable != null)
            {
                objInteractable.ForceGrab();
            }
        }
    }

    public void Close()
    {
        objectToEdit = null;
    }

    public void DeleteObject()
    {
        if (objectToEdit != null)
        {
            Destroy(objectToEdit);
            objectToEdit = null;
        }
    }
}
