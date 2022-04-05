using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ �� ���� �̿��ؼ� Ŀ��� �̵��ϰ�ʹ�.
// ��򰡿� �ε����� �����ϰ�ʹ�.
// �� �� �ε����� Enemy��� �������� ������ʹ�.
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
        //// ������ �� ���� �̿��ؼ� Ŀ��� �̵��ϰ�ʹ�.
        //transform.position += dir * speed * Time.deltaTime;
    }

    // ��򰡿� �ε����� �����ϰ�ʹ�.
    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
    }
}
