using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRaycast : MonoBehaviour
{
    public Camera cam;

    public float distance = 3.0f;


    public LayerMask layermask;

    void Start()
    {
        
    }
    
    void Update()
    {
        RayCastingInteractHandler();
    }

    void RayCastingInteractHandler()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        // 핸들러 오브젝트 레이캐스트
        if (Physics.Raycast(ray, out hit, distance, layermask))
        {
            if (hit.collider.transform.parent.name.Equals("Button01"))
            {
                print("버튼 눌려졌다.");
            }
            if (hit.collider.name.Equals("Grabbable Handler"))
            {
                print("문 눌렀다.");
            }
            print("들어옴");
        }

        // 아이템 오브젝트 레이캐스트
    }
}
