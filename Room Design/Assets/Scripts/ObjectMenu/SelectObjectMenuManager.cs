using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectObjectMenuManager : MonoBehaviour
{
    public Transform head;
    public Vector3 offset;
    public float scale = 0.2f;
    public GameObject selectMenu;
    public InputActionProperty showButton;

    private Vector3 lastForward;
    private Vector3 lastRight;
    private Vector3 lastUp;

    void Awake()
    {
        //scale to half the current size
        selectMenu.transform.localScale = selectMenu.transform.localScale * scale;
        selectMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            selectMenu.SetActive(!selectMenu.activeSelf);
            lastForward = head.forward;
            lastRight = head.right;
            lastUp = head.up;
            //selectMenu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        }

        if (selectMenu.activeSelf)
        {
            selectMenu.transform.LookAt(head);
            //position according to head position and direction
            selectMenu.transform.position = head.position + lastForward * offset.z + lastRight * offset.x + lastUp * offset.y;
            
        }
        //selectMenu.transform.LookAt(new Vector3(head.position.x, selectMenu.transform.position.y, head.position.z));
        //selectMenu.transform.forward *= -1;
    }
}
