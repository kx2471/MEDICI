using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 태어날때 이동할 속도를 Rigidbody에게 알려주고싶다.
// 이동방향은 내 앞방향으로 하고싶다.
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
        // 반경 3M안의 적에게 데미지를 3 주고싶다.
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
