using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 체력을 표현하고싶다.
public class EnemyHP : MonoBehaviour
{
    public int maxHP = 2;
    int hp;
    public Slider sliderHP;
    public int HP {
        get { return hp; }
        set {
            hp = value;
            sliderHP.value = hp;
        }
    }
    void Start()
    {
        // 태어날때 체력을 최대체력으로 하고싶다.
        sliderHP.maxValue = maxHP;
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
