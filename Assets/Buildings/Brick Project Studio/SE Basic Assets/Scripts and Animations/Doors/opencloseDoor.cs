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

		private float distance = 15.0f;

		void Start()
		{
			open = false;

            // 맵 활성화 하면 opencloseDoor.cs 에서 player Transform을 ARCamera Transform으로 종속시키기 
			Player = Camera.main.transform;
		}

/*
		void OnMouseOver()
		{
			{
				if (Player)
				{
					float dist = Vector3.Distance(Player.position, transform.position);
					if (dist < distance)
					{
						if (open == false)
						{
							if (Input.GetMouseButtonDown(0))
							{
								StartCoroutine(opening());
							}
						}
						else
						{
							if (open == true)
							{
								if (Input.GetMouseButtonDown(0))
								{
									StartCoroutine(closing());
								}
							}

						}

					}
				}

			}

		}
		*/
		
		// void OnTouchOver()
		// {
		// 	if(Player)
		// 	{
		// 		float dist = Vector3.Distance(Camera.main.transform.position, transform.position);
		// 		if(dist < distance)
		// 		{
		// 			if(open == false)
		// 			{
		// 				if(MyARRaycast.ARManager.mapSpawned)
		// 				{
		// 					if(Input.touchCount > 0)
		// 					{
		// 						Touch touch = Input.GetTouch(0);

		// 						touchPosition = touch.position;

		// 						if(touch.phase == TouchPhase.Began)
		// 						{
		// 							Ray ray = Camera.main.ScreenPointToRay(touch.position);
		// 							RaycastHit hitObject;
		// 							if(Physics.Raycast(ray, out hitObject, maxDistance))
		// 							{
		// 								// 문
		// 								if(hitObject.transform.gameObject.CompareTag("Door"))
		// 								{
		// 									opencloseDoor mycoroutine = hitObject.transform.GetComponent<opencloseDoor>();
		// 									mycoroutine.StartCoroutine(mycoroutine.opening());
		// 								}
		// 								// 열쇠
		// 								if(hitObject.transform.gameObject.CompareTag("Item"))
		// 								{
		// 									// 열쇠 얻는 스크립트
		// 								}
		// 							}
		// 						}
		// 					}

		// 				}
		// 			}
		// 			else
		// 			{

		// 			}
		// 		}
		// 	}
		// }

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