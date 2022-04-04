using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �¾�� �̵��� �ӵ��� Rigidbody���� �˷��ְ�ʹ�.
// �̵������� �� �չ������� �ϰ�ʹ�.
public class Grenade : MonoBehaviour
{
    public float speed = 10;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        rb.AddTorque(transform.right * 20, ForceMode.Impulse);
    }

    public float radius = 3;
    public GameObject explosionFactory;
    private void OnCollisionEnter(Collision collision)
    {
        // �ݰ� 3M���� ������ �������� 3 �ְ�ʹ�.
        Collider[] cols = Physics.OverlapSphere(transform.position, radius);

        for (int i = 0; i < cols.Length; i++)
        {
            Enemy enemy = cols[i].GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TryDamage(3);
            }
        }

        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;
        Destroy(gameObject);

    }

}
