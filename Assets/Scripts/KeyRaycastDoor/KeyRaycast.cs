using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeySystem
{
    public class KeyRaycast : MonoBehaviour
    {
        public int rayLength = 5;
        public LayerMask layerMaskInteract;
        public string excluseLayerName = null;
        
        KeyItemController raycastedObject;
        public KeyCode openDoorKey = KeyCode.Mouse0;

        public Image crosshair = null;
        bool isCrosshairActive;
        bool doOnce;

        string interactableTag = "InteractiveObject";

        void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;

            if(Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
            {
                if(hit.collider.CompareTag(interactableTag))
                {
                    if(!doOnce)
                    {
                        raycastedObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                    if(Input.GetKeyDown(openDoorKey))
                    {
                        raycastedObject.ObjectInteraction();
                    }
                }
            }
            else
            {
                if(isCrosshairActive)
                {
                    CrosshairChange(false);
                    doOnce = false;
                }
            }
        }

        void CrosshairChange(bool on)
        {
            if(on && !doOnce)
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.white;
                isCrosshairActive = false;
            }
        }
    }
}
