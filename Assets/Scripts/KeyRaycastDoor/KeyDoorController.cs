using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        Animator doorAnim;
        bool doorOpen = false;
        [Header("Animation Names")]
        public string openAnimationName = "DoorOpen";
        public string closeAnimationName = "DoorClose";

        public int timeToShowUI = 1;
        public GameObject showDoorLockedUI = null;

        public KeyInventory _keyInventory = null;
        public int waitTimer = 1;
        public bool pauseInteraction = false;

        void Awake()
        {
            doorAnim = gameObject.GetComponent<Animator>();
        }

        IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }

        public void PlayAnimation()
        {
            if(_keyInventory.hasRedKey)
            {
                OpenDoor();
            }
            /* 다른 키
            else if(_keyInventory.hasBlueKey)
            {
                OpenDoor();
            }
            */
            else
            {
                StartCoroutine(ShowDoorLocked());
            }
        }

        void OpenDoor()
        {
            if(!doorOpen && !pauseInteraction)
                {
                    doorAnim.Play(openAnimationName, 0, 0.0f);
                    doorOpen = true;
                    StartCoroutine(PauseDoorInteraction());
                }
                else if(doorOpen && !pauseInteraction)
                {
                    doorAnim.Play(closeAnimationName, 0, 0.0f);
                    doorOpen = false;
                    StartCoroutine(PauseDoorInteraction());
                }
        }

        IEnumerator ShowDoorLocked()
        {
            showDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showDoorLockedUI.SetActive(false);
        }
    }
}
