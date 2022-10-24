using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        bool doorOpen = false;
        [Header("Animation")]
        public Animator openandclose;

        public int timeToShowUI = 1;
        public GameObject showDoorLockedUI = null;

        public KeyInventory _keyInventory = null;
        public bool pauseInteraction = false;

        public int checkKeys = 6;

        public void PlayAnimation()
        {
            if(_keyInventory.hasKeys >= checkKeys)
            {
                OpenDoor();
            }
            else
            {
                StartCoroutine(ShowDoorLocked());
            }
        }

        void OpenDoor()
        {
            if(!doorOpen && !pauseInteraction)
            {
                StartCoroutine(opening());
            }
            else if(doorOpen && !pauseInteraction)
            {
                StartCoroutine(closing());
            }
        }

        IEnumerator ShowDoorLocked()
        {
            showDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showDoorLockedUI.SetActive(false);
        }
        
        IEnumerator opening()
		{
			openandclose.Play("Opening");
			doorOpen = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			openandclose.Play("Closing");
			doorOpen = false;
			yield return new WaitForSeconds(.5f);
		}

    }
}
