using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAlarm : MonoBehaviour
{

    public static TestAlarm Instance;
    private void Awake()
    {
        Instance = this;
    }

    public System.Action<GameObject> triggerEvent;


    private void OnTriggerEnter(Collider other)
    {
        if(triggerEvent != null)
        {
            triggerEvent(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
