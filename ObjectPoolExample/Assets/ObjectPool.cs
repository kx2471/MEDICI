using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private void Awake()
    {
        instance = this;

        list = new Dictionary<string, List<GameObject>>();
        inActiveList = new Dictionary<string, List<GameObject>>();
    }

    GameObject bulletFactory = null;
    public int maxCount = 20;
    public Dictionary<string, List<GameObject>> list;
    // 안보이는 목록을 만들어서 관리하고싶다.
    Dictionary<string, List<GameObject>> inActiveList;

    public void CreateInstance(string prefabName, Transform parent, int amount)
    {
        string key = prefabName;
        maxCount = amount;
        bulletFactory = (GameObject)Resources.Load("Prefabs/" + prefabName);
        // 미리 maxCount만큼 만들어놓고 비활성화 하고싶다.
        // 목록에 담아놓고싶다.
        for (int i = 0; i < maxCount; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.parent = parent;
            bullet.name = key;
            bullet.SetActive(false);
            // 만약 list에 key가 존재하지 않는다면 
            if (false == list.ContainsKey(key))
            {
                // key와 value를 추가하고싶다.
                list.Add(key, new List<GameObject>());
                inActiveList.Add(key, new List<GameObject>());
            }

            list[key].Add(bullet);
            inActiveList[key].Add(bullet);
        }
    }



    public GameObject GetInactiveBullet(string key)
    {
        if (false == inActiveList.ContainsKey(key))
        {
            return null;
        }
        // 만약 비활성목록이 0개 보다 크다면
        if (inActiveList[key].Count > 0)
        {
            //  비활성목록의 첫번째 총알을 활성화하고
            inActiveList[key][0].SetActive(true);
            GameObject temp = inActiveList[key][0];
            //  비활성목록에서 제거하고
            inActiveList[key].RemoveAt(0);
            //  반환하고싶다.
            return temp;
        }
        // 그렇지않다면(만약 비활성목록이 0개라면)        //  null을 반환하고싶다.

        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.parent = list[key][0].transform.parent;
        bullet.name = key;
        list[key].Add(bullet);
        bullet.SetActive(true);
        return bullet;
    }

    public void AddInactiveList(GameObject obj)
    {
        obj.SetActive(false);
        string key = obj.name;
        if (inActiveList.ContainsKey(key))
        {
            if (false == inActiveList[key].Contains(obj))
            {
                inActiveList[key].Add(obj);
            }
        }
    }

    public static bool IsObjectPoolObject(GameObject obj)
    {
        string key = obj.name;
        if (ObjectPool.instance.list.ContainsKey(key))
        {
            return ObjectPool.instance.list[key].Contains(obj);
        }

        return false;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
