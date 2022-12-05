using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectObjectMenuManager : MonoBehaviour
{
    public Transform head;
    public float spawnDistance = 2;
    public GameObject selectMenu;
    public InputActionProperty showButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            selectMenu.SetActive(!selectMenu.activeSelf);
            
            selectMenu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
            Debug.Log(selectMenu.transform.position);
        }

        selectMenu.transform.LookAt(new Vector3(head.position.x, selectMenu.transform.position.y, head.position.z));
        selectMenu.transform.forward *= -1;
    }
}
