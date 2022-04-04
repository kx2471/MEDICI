using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ü���� ǥ���ϰ�ʹ�.
// �¾�� ü���� �ִ�ü������ �ϰ�ʹ�.
// ���� �ε������� ü���� 1�� ���ҽ�Ű��ʹ�.
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
        // �¾�� ü���� �ִ�ü������ �ϰ�ʹ�.
        sliderHP.maxValue = maxHP;
        HP = maxHP; // set

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
