using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJE_TreeRotation : MonoBehaviour
{
    public Transform Target;
    // Update is called once per frame
    void Update()
    {


        transform.RotateAround(Target.position, Vector3.up, 2 * Time.deltaTime);
    }
}
