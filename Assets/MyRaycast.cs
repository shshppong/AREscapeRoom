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

        // �ڵ鷯 ������Ʈ ����ĳ��Ʈ
        if (Physics.Raycast(ray, out hit, distance, layermask))
        {
            if (hit.collider.transform.parent.name.Equals("Button01"))
            {
                print("��ư ��������.");
            }
            if (hit.collider.name.Equals("Grabbable Handler"))
            {
                print("�� ������.");
            }
            print("����");
        }

        // ������ ������Ʈ ����ĳ��Ʈ
    }
}
