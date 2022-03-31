using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Dictionary<string, int> dic = new Dictionary<string, int>();
        for (int i = 0; i < 5; i++)
        {
            dic.Add(""+i, i);
        }

        for(int i = 0; i < dic.Count; i++)
        {
            print(dic["" + i]);
        }



        //List <int> list = new List<int>();
        //for(int i = 0; i < 5; i++)
        //{
        //    list.Add(1);
        //}
        //for (int i = 0; i < list.Count; i++)
        //{
        //    list[i] = i;
            
        //}
        //list.RemoveAt(2);
        //for(int i = 0; i < list.Count; i++)
        //{
        //    print(list[i]);
        //}
        //list.Insert(2, 10);
        //for (int i = 0; i < list.Count; i++)
        //{
        //    print(list[i]);
        //}
        ////int[] a = new int[5];
        //for (int i = 0; i < a.Length; i++)
        //{
        //
        //   a[0] = 1;
        //}
        //
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
