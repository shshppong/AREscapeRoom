using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEnterArea : MonoBehaviour
{
    private Transform player;
    
    public KeySystem.KeyInventory _keyInventory = null;

    void Start()
    {
        player = Camera.main.transform;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // 만약 열쇠를 다 모았으며, 플레이어가 입장 할 때
        
        // 입장한 대상이 메인카메라. 즉, 플레이어 일 때
        if(other.gameObject.CompareTag("MainCamera"))
        {
            if(_keyInventory.hasKeys >= 6)
            {
                SceneManager.LoadScene("Clear");
            }
        }
    }
}
