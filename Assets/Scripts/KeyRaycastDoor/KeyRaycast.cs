using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyRaycast : MonoBehaviour
    {
        KeyItemController raycastedObject;

        bool doOnce;

		[SerializeField]
		private Transform Player;

		private float distance = MyARRaycast.MySetDistanceObject.distance;
		private Vector2 touchPosition = default;

        void Start()
        {
            Player = Camera.main.transform;
            raycastedObject = GetComponent<KeyItemController>();
        }


        void OnMouseOver()
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
                            raycastedObject.ObjectInteraction();
                        }
                    }
                }
            }
		}
    }
}
