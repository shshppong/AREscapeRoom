using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{

	public class Drawer_Pull_X : MonoBehaviour
	{

		public Animator pull_01;
		public bool open;

		[SerializeField]
		private Transform Player;

		private float distance = MyARRaycast.MySetDistanceObject.distance;

		// 터치
		private Vector2 touchPosition = default;

		void Start()
		{
			open = false;

            // 맵 활성화 하면 opencloseDoor.cs 에서 player Transform을 ARCamera Transform으로 종속시키기 
			Player = Camera.main.transform;
		}

		void OnMouseOver()
		{
			{
				if(Player)
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
			GamePlayManager.Instance.ToggleOnAudio(GamePlayManager.AudioType.DOOR_FOLDING_OPEN);
			
			print("you are opening the door");
			pull_01.Play("openpull_01");
			open = true;
			yield return new WaitForSeconds(.5f);
			GamePlayManager.Instance.ToggleOffAudio(GamePlayManager.AudioType.DOOR_FOLDING_OPEN);
		}

		IEnumerator closing()
		{
			GamePlayManager.Instance.ToggleOnAudio(GamePlayManager.AudioType.DOOR_FOLDING_CLOSE);

			print("you are closing the door");
			pull_01.Play("closepush_01");
			open = false;
			yield return new WaitForSeconds(.5f);
			GamePlayManager.Instance.ToggleOffAudio(GamePlayManager.AudioType.DOOR_FOLDING_CLOSE);
		}


	}
}