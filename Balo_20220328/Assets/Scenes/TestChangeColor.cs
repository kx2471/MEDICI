using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestAlarm.Instance.triggerEvent += OnChangeColor;
    }

    void OnChangeColor(GameObject obj)
    {
        GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
