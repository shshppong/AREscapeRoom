using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        public bool redDoor = false;
        public bool redKey = false;

        public KeyInventory _keyInventory = null;

        KeyDoorController doorObject;

        void Start()
        {
            if(redDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }
        }

        public void ObjectInteraction()
        {
            if(redDoor)
            {
                doorObject.PlayAnimation();
            }else if(redKey)
            {
                _keyInventory.hasRedKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}
