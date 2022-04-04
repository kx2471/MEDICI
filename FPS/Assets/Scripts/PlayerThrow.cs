using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자가 G키를 누르면 폭탄공장에서 폭탄을 만들어서 내 위치에 배치하고싶다.
// 폭탄의 앞방향을 내가 던지고자 하는 방향(내앞으로 45도)으로 회전시키고싶다.
public class PlayerThrow : MonoBehaviour
{
    public GameObject grenadeFactory;
    public Transform grenadeThrowPosition;

    void Update()
    {
        // 1. 만약 사용자가 G키를 누르면
        if (Input.GetKeyDown(KeyCode.G))
        {
            // 2. 폭탄공장에서 폭탄을 만들어서
            GameObject grenade = Instantiate(grenadeFactory);
            // 3. grenadeThrowPosition에 배치하고싶다.
            grenade.transform.position = grenadeThrowPosition.position;
            // 4. 폭탄의 앞방향을 내가 던지고자 하는 방향(내앞으로 50도)으로 회전시키고싶다.

            //Quaternion q = grenadeThrowPosition.rotation * Quaternion.Euler(-50, 0, 0);
            //grenade.transform.rotation = q;
            grenade.transform.forward = grenadeThrowPosition.forward;


           

        }
    }
}
