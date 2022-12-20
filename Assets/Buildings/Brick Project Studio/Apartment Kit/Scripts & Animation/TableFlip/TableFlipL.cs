using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyARRaycast
{
	public class TableFlipL: MonoBehaviour
	{
		public Animator FlipL;
		public bool open;

		[SerializeField]
		private Transform Player;

		private float distance = MyARRaycast.MySetDistanceObject.distance;
		private Vector2 touchPosition = default;

		void Start()
		{
			open = false;

			Player = Camera.main.transform;
		}

		void OnMouseOver()
		{
			{
				if (Player)
				{
					float dist = Vector3.Distance(Camera.main.transform.position, transform.position);
					if(dist < distance)
					{
						if(Input.touchCount > 0)
						{
							Touch touch = Input.GetTouch(0);

							touchPosition = touch.position;

							if(touch.phase == TouchPhase.Began)
							{
								if(open == false)
								{
									StartCoroutine(opening());
								}
								else
								{
									StartCoroutine(closing());
								}
							}
						}
					}
				}
			}

		}

		IEnumerator opening()
		{
			GamePlayManager.Instance.random = Random.Range(1, 4);
			GamePlayManager.Instance.ToggleOnAudio(GamePlayManager.Instance.random);

			print ("you are opening the door");
			FlipL.Play ("Lup");
			open = true;
			yield return new WaitForSeconds (.5f);
			GamePlayManager.Instance.ToggleOffAudio(GamePlayManager.AudioType.WINDOW_OPEN);
		}

		IEnumerator closing()
		{
			GamePlayManager.Instance.ToggleOnAudio(GamePlayManager.AudioType.WINDOW_CLOSE);

			print ("you are closing the door");
			FlipL.Play ("Ldown");
			open = false;
			yield return new WaitForSeconds (.5f);
			GamePlayManager.Instance.ToggleOffAudio(GamePlayManager.AudioType.WINDOW_OPEN);
		}


	}
}
