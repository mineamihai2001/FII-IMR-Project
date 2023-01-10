using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PrimaryButtonRayHandler : MonoBehaviour
{
    public XRRayInteractor ray;
    public InputActionProperty inputAction;

    void Update() {
        if(inputAction.action.WasPressedThisFrame())
        {
            Vector3 rayOrigin = ray.transform.position;
            Vector3 rayDirection = ray.transform.forward;

            var itHits = Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hitInfo, ray.maxRaycastDistance);

            if (itHits)
            {
                var obj = hitInfo.collider.gameObject;
                var interactable = obj.GetComponent<ObjectInteractable>();
                if (interactable != null)
                    interactable.ClickHandler();
            }
        }
    }
}
