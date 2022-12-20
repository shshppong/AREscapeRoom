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

        public void PlayAnimation()
        {
            if(_keyInventory.hasKeys >= GamePlayManager.Instance.checkKeys)
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
			GamePlayManager.Instance.random = Random.Range(12, 14);
			GamePlayManager.Instance.ToggleOnAudio(GamePlayManager.Instance.random);
            showDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
			GamePlayManager.Instance.ToggleOffAudio(GamePlayManager.Instance.random);
            showDoorLockedUI.SetActive(false);
        }
        
        IEnumerator opening()
		{
			GamePlayManager.Instance.random = Random.Range(1, 4);
			GamePlayManager.Instance.ToggleOnAudio(GamePlayManager.Instance.random);

			openandclose.Play("Opening");
			doorOpen = true;
			yield return new WaitForSeconds(.5f);
			GamePlayManager.Instance.ToggleOffAudio(GamePlayManager.Instance.random);
		}

		IEnumerator closing()
		{
			GamePlayManager.Instance.random = Random.Range(4, 7);
			GamePlayManager.Instance.ToggleOnAudio(GamePlayManager.Instance.random);

			openandclose.Play("Closing");
			doorOpen = false;
			yield return new WaitForSeconds(.5f);
			GamePlayManager.Instance.ToggleOffAudio(GamePlayManager.Instance.random);
		}

    }
}
