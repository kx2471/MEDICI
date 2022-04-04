using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJE_DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // ºÎµúÈù »ó´ë¸¦ ÆÄ±«ÇÏ°í½Í´Ù.
        Destroy(other.gameObject);
    }
}