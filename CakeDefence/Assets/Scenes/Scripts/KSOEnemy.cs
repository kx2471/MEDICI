using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSOEnemy : MonoBehaviour
{

    public float speed = 5;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        // �¾�� �̵������� ���ϰ�ʹ�. 
      
 
           
            dir = Vector3.down;


    }
    // Update is called once per frame
    void Update()
    {
        // ��ư��鼭 �� ���� �������� �̵��ϰ�ʹ�.
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ���װ� 
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            Destroy(other.gameObject);
        }
    }
}
