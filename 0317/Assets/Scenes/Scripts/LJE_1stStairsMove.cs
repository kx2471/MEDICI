using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJE_1stStairsMove : MonoBehaviour
{
    public float rotSpeed = 100f;
    public float SpeedZ = 50f;



    // Update is called once per frame
    private void OnCollisionStay(Collision collision)
    {
        // 1stStairs∞° Playerø° ¥Í¿∏∏È 
        if (collision.gameObject.name.Contains("Player"))
        {
            // transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime));
            Start();
        }
        else
        {
            print("wldms");

        }
    }

    void Start()
    {
        {
            
            transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, SpeedZ * Time.deltaTime));
            
        }
        
    }
}
