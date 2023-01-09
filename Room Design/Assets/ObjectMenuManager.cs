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
        if (showButton.action.WasPressedThisFrame())
            menu.SetActive(!menu.activeSelf);

        if (menu.activeSelf)
        {
            menu.transform.position = (mainCamera.transform.position + objectToEdit.transform.position) / 2;
        }
    }
}
