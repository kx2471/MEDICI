using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 로켓은 그 점을 이용해서 커브로 이동하고싶다.
// 어딘가에 부딪히면 폭발하고싶다.
// 그 때 부딪것이 Enemy라면 데미지를 입히고싶다.
public class Rocket : MonoBehaviour
{
    Vector3[] path;

    public void SetPath(Vector3[] path)
    {
        this.path = path.Clone() as Vector3[];
    }
    // Start is called before the first frame update
    void Start()
    {
        Vector3 p1 = path[0];
        Vector3 p2 = path[1];
        Vector3 dir = p2 - p1;
        transform.forward = dir;
    }
    float t;
    // Update is called once per frame
    public float speed = 5;
    int index = 0;
    public float timeSpeed = 5;
    void Update()
    {
        if (index >= path.Length - 1)
        {
            return;
        }
        Vector3 p1 = path[index];
        Vector3 p2 = path[index + 1];
        transform.position = Vector3.Lerp(p1, p2, t);
        Vector3 dir = p2 - p1;
        Quaternion targetRotation = Quaternion.LookRotation(dir, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5);

        if (index < path.Length - 1)
        {
            t += Time.deltaTime * timeSpeed;
            if (t > 1)
            {
                index++;
                t = 0;
            }
        }

        //Vector3 dir = ;
        //// 로켓은 그 점을 이용해서 커브로 이동하고싶다.
        //transform.position += dir * speed * Time.deltaTime;
    }

    // 어딘가에 부딪히면 폭발하고싶다.
    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
    }
}
