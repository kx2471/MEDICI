using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 배경을 스크롤 하고싶다.
// 태어날 때 재질을 기억했다가
// 살아가면서 재질의 offset값을 위로 이동하고싶다.
public class Background : MonoBehaviour
{
    // 재질
    Material mat; // Cache 
    // 스크롤 속도
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        // 태어날 때 재질을 기억했다가
        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
        mat = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        // 살아가면서 재질의 offset값을 위로 이동하고싶다.
        mat.mainTextureOffset += Vector2.up * speed * Time.deltaTime;
    }
}
