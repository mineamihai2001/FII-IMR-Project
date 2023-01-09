using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectMenuManager : MonoBehaviour
{
    /*public GameObject anchor;
    public Transform lookAt;
    public float scale = 0.05f;
    public GameObject selectMenu;
    */
    public InputActionProperty showButton;
    public GameObject menu;
    public GameObject objectToEdit;
    public Camera mainCamera;

    void Awake()
    {
        /*selectMenu.transform.localScale = selectMenu.transform.localScale * scale;*/
        menu.SetActive(false);
    }

    private void Update()
    {
        if (showButton.action.WasPressedThisFrame())
            menu.SetActive(!menu.activeSelf);

        if (menu.activeSelf)
        {
            menu.transform.position = (mainCamera.transform.position + objectToEdit.transform.position)/2;
            Debug.Log(mainCamera.transform.position);
            Debug.Log(objectToEdit.transform.position);

        }
    }
}
