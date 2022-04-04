using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Floor floor = other.gameObject.GetComponentInParent<Floor>();
        if (floor != null)
        {
            floor.floorManager.count--;
            Destroy(floor.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
