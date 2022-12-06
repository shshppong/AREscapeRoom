using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool push;

    private Transform Player;
    private Vector2 touchPosition = default;

    public GameObject lightObj;

    void Start()
    {
        push = false;
        lightObj.SetActive(false);

        Player = Camera.main.transform;
    }

    // void LateUpdate()
    // {
    //     transform.position = camChildObjPos.position;
    //     transform.rotation = camChildObjPos.rotation;
    // }

    // 마우스 커서가 이 오브젝트 안에 들어오면 실행되는 함수
    void OnMouseOver()
    {
        if(Player) // 대상이 플레이어의 카메라라면
        {
            if(Input.touchCount > 0) // 터치를 한 상태라면
            {
                Touch touch = Input.GetTouch(0);
                touchPosition = touch.position;

                if(touch.phase == TouchPhase.Began)
                {
                    if(push == false)
                    {
                        lightObj.SetActive(true);
                        push = true;
                    }
                    else
                    {
                        lightObj.SetActive(false);
                        push = false;
                    }
                }
            }
            #if UNITY_EDITOR
            if(Input.GetMouseButtonDown(0))
            {
                if(push == false)
                {
                    lightObj.SetActive(true);
                    push = true;
                }
                else
                {
                    lightObj.SetActive(false);
                    push = false;
                }
            }
            #endif
        }
    }
}
