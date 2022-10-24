using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyARRaycast

{
	public class OvenFlip: MonoBehaviour
	{

		public Animator openandcloseoven;
		public bool open;
		public Transform Player;

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
			print("you are opening the Window");
			openandcloseoven.Play("OpenOven");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the Window");
			openandcloseoven.Play("ClosingOven");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}