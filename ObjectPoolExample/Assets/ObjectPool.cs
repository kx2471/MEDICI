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
    // �Ⱥ��̴� ����� ���� �����ϰ�ʹ�.
    Dictionary<string, List<GameObject>> inActiveList;

    public void CreateInstance(string prefabName, Transform parent, int amount)
    {
        string key = prefabName;
        maxCount = amount;
        bulletFactory = (GameObject)Resources.Load("Prefabs/" + prefabName);
        // �̸� maxCount��ŭ �������� ��Ȱ��ȭ �ϰ�ʹ�.
        // ��Ͽ� ��Ƴ���ʹ�.
        for (int i = 0; i < maxCount; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.parent = parent;
            bullet.name = key;
            bullet.SetActive(false);
            // ���� list�� key�� �������� �ʴ´ٸ� 
            if (false == list.ContainsKey(key))
            {
                // key�� value�� �߰��ϰ�ʹ�.
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
        // ���� ��Ȱ������� 0�� ���� ũ�ٸ�
        if (inActiveList[key].Count > 0)
        {
            //  ��Ȱ������� ù��° �Ѿ��� Ȱ��ȭ�ϰ�
            inActiveList[key][0].SetActive(true);
            GameObject temp = inActiveList[key][0];
            //  ��Ȱ����Ͽ��� �����ϰ�
            inActiveList[key].RemoveAt(0);
            //  ��ȯ�ϰ�ʹ�.
            return temp;
        }
        // �׷����ʴٸ�(���� ��Ȱ������� 0�����)        //  null�� ��ȯ�ϰ�ʹ�.

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
