using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseWindow1 : MonoBehaviour
	{

		public Animator openandclosewindow1;
		public bool open;
		public Transform Player;

		void Start()
		{
			open = false;
		}

		void OnMouseOver()
		{
			{
				if (Player)
				{
					float dist = Vector3.Distance(Player.position, transform.position);
					if (dist < 15)
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

		IEnumerator opening()
		{
			GamePlayManager.Instance.ToggleOnAudio(GamePlayManager.AudioType.WINDOW_OPEN);

			print("you are opening the Window");
			openandclosewindow1.Play("Openingwindow 1");
			open = true;
			yield return new WaitForSeconds(.5f);
			GamePlayManager.Instance.ToggleOffAudio(GamePlayManager.Instance.random);
		}

		IEnumerator closing()
		{
			GamePlayManager.Instance.random = Random.Range(4, 7);
			GamePlayManager.Instance.ToggleOnAudio(GamePlayManager.Instance.random);

			print("you are closing the Window");
			openandclosewindow1.Play("Closingwindow 1");
			open = false;
			yield return new WaitForSeconds(.5f);
			GamePlayManager.Instance.ToggleOffAudio(GamePlayManager.Instance.random);
		}


	}
}