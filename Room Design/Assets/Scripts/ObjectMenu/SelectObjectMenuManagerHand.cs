using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectObjectMenuManagerHand : MonoBehaviour
{
    public GameObject anchor;
    public Transform lookAt;
    public float scale = 0.05f;
    public GameObject selectMenu;

    public InputActionProperty showButton;

    void Awake()
    {
        selectMenu.transform.localScale = selectMenu.transform.localScale * scale;
        selectMenu.SetActive(false);
    }

    private void Update()
    {
        if (showButton.action.WasPressedThisFrame())
            selectMenu.SetActive(!selectMenu.activeSelf);

        if (selectMenu.activeSelf)
        {
            selectMenu.transform.LookAt(lookAt);
            selectMenu.transform.position = anchor.transform.position;
        }
    }
}
