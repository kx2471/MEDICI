using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject rocketFactory;
    public GameObject target;

    public LineRenderer lr;
    public int[] path;

    public int maxCount = 20;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GameObject rocket = Instantiate(rocketFactory);
            rocket.transform.position = transform.position;

            Rocket r = rocket.GetComponent<Rocket>();
            r.                SetPath(MakePath());
        }
    }

    Vector3[] MakePath()
    {
        Vector3 dir = Vector3.up * Quaternion.Euler(0, 0, 0);

        dir *= 3.85f;


        Vector3[] path = new Vector3[maxCount];
        Vector3 p1 = transform.position;
        Vector3 p2 = transform.position + new Vector3(0, 3.85f, -8.25f);
        Vector3 p3 = transform.position;
        for(int i = 0; i < maxCount; i++)
        {
            float t = (float)i / (maxCount - 1);
            path[i] = GetCurvePosition(p1, p2, p3, t);
            
        }

        return path;
    }

    Vector3 GetCurvePosition(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 ab = Vector3.Lerp(a, b, t);
        Vector3 bc = Vector3.Lerp(b, c, t);

        return Vector3.Lerp(ab, bc, t);
    }
}
