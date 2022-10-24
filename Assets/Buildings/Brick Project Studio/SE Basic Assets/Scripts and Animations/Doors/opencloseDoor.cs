using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyARRaycast
{
	public class opencloseDoor : MonoBehaviour
	{

		public Animator openandclose;
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

		public IEnumerator opening()
		{
			print("you are opening the door");
			openandclose.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		public IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}