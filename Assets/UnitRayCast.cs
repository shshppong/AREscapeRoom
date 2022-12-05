using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRayCast : MonoBehaviour
{
    public Animator animator;    // 유니티 애니메이터 컴포넌트를 스크립트에다가 마우스 끌어당기기 ㄱㄱ

    private Transform Player;
    public float distance = 10f;
    private Vector2 touchPosition = default;

    void Start()
    {
        Player = Camera.main.transform;
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
                        int rand = Random.Range(0, 3);
                        animator.SetInteger("DamageType", rand);
                        animator.SetTrigger("Damage");
                    }
                }
            }
        }
    }
}
