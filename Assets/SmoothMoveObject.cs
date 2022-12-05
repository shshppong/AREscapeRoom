using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMoveObject : MonoBehaviour
{
    Transform player;

    public float smoothSpeed = 10.0f;

    void Start()
    {
        player = Camera.main.transform;
    }

    void FixedUpdate()
    {
        Vector3 targetPos = player.position;
        Quaternion targetRot = player.rotation;

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * smoothSpeed);
    }
    // void LateUpdate()
    // {
    //     transform.position = player.position;
    //     transform.rotation = player.rotation;
    // }
}
