using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자가 좌우키를 누르면 좌우로 이동하고싶다.
public class Player : MonoBehaviour
{
    // 목적지
    Vector3 targetPosition;
    // 목적지 목록
    public Transform[] list;
    // 현재 목적지목록의 인덱스
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        targetPosition.x = list[index].position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // 만약 index가 0보다 크고 왼쪽 키를 누르면
        if (index > 0 && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            index--;
        }
        // 만약 index < list.Length - 1 이고 오른쪽 키를 누르면
        if (index < list.Length - 1 && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            index++;
        }

        targetPosition.x = list[index].position.x;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5);
    }
}
