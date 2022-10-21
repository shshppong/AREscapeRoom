using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

namespace MyARRaycast
{
    public class ARManager : MonoBehaviour
    {
        ARRaycastManager arRaycastManager;
        Vector2 viewCenter;
        public GameObject indicator;
        public GameObject model;
        

        public bool mapSpawned = false;

        private Vector2 touchPosition = default;

        float maxDistance = 15.0f;

        // Start is called before the first frame update
        void Start()
        {
            arRaycastManager = GetComponent<ARRaycastManager>();
            viewCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
            model.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if(!mapSpawned)
            {
                onFirst();
            }
            else
            {
                MyRaycastARManager();
            }
        }

        void onFirst()
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (arRaycastManager.Raycast(viewCenter, hits) && model.activeSelf==false)
            {
                Pose pos = hits[0].pose;
                pos.rotation = Quaternion.LookRotation(
                    new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z));

                indicator.SetActive(true);
                indicator.transform.SetPositionAndRotation(pos.position, pos.rotation);

            }
            else
            {
                indicator.SetActive(false);

            }

            if (model.activeSelf == false)
            {
                // 버튼 위가 아닌 곳에 화면을 터치하였을 때에...
                if (Input.GetMouseButtonDown(0))
                {
                    // 인디케이터가 활성화되어 있을 때
                    if (indicator.activeSelf)
                    {

                        model.transform.position = indicator.transform.position;
                        model.transform.rotation = indicator.transform.rotation;
                        model.SetActive(true);
                    
                        // 맵 활성화 하면 opencloseDoor.cs 에서 player Transform을 ARCamera Transform으로 종속시키기 
                        mapSpawned = true;
                        // 플랜 스캔 안하게 끄기
                        GetComponent<ARPlaneManager>().enabled = false;
                    }
                }
            }
        }

        void MyRaycastARManager()
        {
            if(mapSpawned)
            {
                if(Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    touchPosition = touch.position;

                    if(touch.phase == TouchPhase.Began)
                    {
                        Ray ray = Camera.main.ScreenPointToRay(touch.position);
                        RaycastHit hitObject;
                        if(Physics.Raycast(ray, out hitObject, maxDistance))
                        {
                            // 문
                            if(hitObject.transform.gameObject.CompareTag("Door"))
                            {
                                opencloseDoor mycoroutine = hitObject.transform.GetComponent<opencloseDoor>();
                                mycoroutine.StartCoroutine(mycoroutine.opening());
                            }
                            // 열쇠
                            if(hitObject.transform.gameObject.CompareTag("Item"))
                            {
                                // 열쇠 얻는 스크립트
                            }
                        }
                    }
                }

            }
        }
    }
}
