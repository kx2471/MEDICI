using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 체력을 표현하고싶다.
// 태어날때 체력을 최대체력으로 하고싶다.
// 적과 부딪혔을때 체력을 1씩 감소시키고싶다.
public class PlayerHP : MonoBehaviour
{
    public int maxHP = 3;
    int hp;

    public Slider sliderHP;
    public int HP
    {
        get { return hp; }
        set { 
            hp = value;
            sliderHP.value = hp;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 태어날때 체력을 최대체력으로 하고싶다.
        sliderHP.maxValue = maxHP;
        HP = maxHP; // set

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
