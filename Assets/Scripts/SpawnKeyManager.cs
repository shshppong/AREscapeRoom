using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKeyManager : MonoBehaviour
{
    private GameObject[] keySpawnObject;

    public GameObject keyPrefab;

    private int targetValue;

    [SerializeField]
    List<GameObject> showSetList = new List<GameObject>();

    void Start()
    {
        targetValue = GamePlayManager.Instance.checkKeys;
        
        // 스폰 포인트 오브젝트들 전부 불러오기
        // ItemSpawnPoint 태그로 설정한 오브젝트들을 전부 배열에 불러오기
        keySpawnObject = GameObject.FindGameObjectsWithTag("ItemSpawnPoint");

        List<GameObject> keyObjectList = new List<GameObject>(keySpawnObject);

        // 적재된 스폰 포인트들 중에서 랜덤으로 6곳을 뽑아 열쇠를 배치한다.
        // for(int i = 0; i < targetValue; i ++)
        // {
            // int rnd = Random.Range(0, keySpawnObject.Length);
            // GameObject obj = Instantiate(keyPrefab, keyObjectList[rnd].transform.position, keyObjectList[rnd].transform.rotation);
            // obj.transform.parent = keyObjectList[rnd].transform;
            // obj.transform.rotation = new Quaternion(80f, 90f, 0f, 0f);
            // showSetList.Add(obj);
            // keyObjectList.RemoveAt(rnd);
        // }

        while(true)
        {
            if(showSetList.Count >= targetValue) break;

            int rnd = Random.Range(0, keySpawnObject.Length);
            if(showSetList.Contains(keyObjectList[rnd])) return;

            GameObject obj = Instantiate(keyPrefab, keyObjectList[rnd].transform.position, keyObjectList[rnd].transform.rotation);
            obj.transform.parent = keyObjectList[rnd].transform;
            obj.transform.rotation = new Quaternion(80f, 90f, 0f, 0f);
            showSetList.Add(obj);
        }
    }
}
