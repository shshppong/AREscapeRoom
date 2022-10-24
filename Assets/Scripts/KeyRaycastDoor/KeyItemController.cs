using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        public bool redDoor = false;
        public bool key = false;

        public KeyInventory _keyInventory = null;

        KeyDoorController doorObject;

        void Start()
        {
            _keyInventory = GameObject.Find("KeyInventory").GetComponent<KeyInventory>();
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
            }else if(key)
            {
                _keyInventory.hasKeys += 1;
                gameObject.SetActive(false);
            }
        }
    }
}
