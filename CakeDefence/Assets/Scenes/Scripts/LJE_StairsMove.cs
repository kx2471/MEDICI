using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJE_StairsMove : MonoBehaviour
{
    public Transform Target;
    // Update is called once per frame
    void Update()
    {


        transform.RotateAround(Target.position, Vector3.down, 20 * Time.deltaTime);
    }
}
