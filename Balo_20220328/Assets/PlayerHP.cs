using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    int hpPotion;
    public Text textHpPotion;
    public int HP_Potion
    {
        get{ return hpPotion; }
        set
        {
            hpPotion = value;
            textHpPotion.text = "x" + hpPotion;
        }
    }

    int Hp;
    public int MaxHP = 5;
    public GameObject[] hpObjectList;

    public int HP
    {
        get { return Hp; }
        set
        {
            Hp = value;

            //ü���� �����Ǿ������� ���� ó��
            for (int i = 0; i < hpObjectList.Length; i++)
            {
                hpObjectList[i].SetActive(HP <= i);
            }
        }
    }

    public void ResetHpObject()
    {
       
        //�ִ�ü�� ������ŭ ü��UI�� Ȱ��ȭ �ؾ� �Ѵ�.
        for (int i = 0; i < hpObjectList.Length; i++)
        {
            hpObjectList[i].transform.parent.gameObject.SetActive(i < MaxHP);
        }
    }

    public void AddHP(int value)
    {
        MaxHP += value;
        if(MaxHP > hpObjectList.Length)
        {
            MaxHP = hpObjectList.Length;
        }
        ResetHpObject();
        HP = HP;
    }


    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
        ResetHpObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (HP_Potion > 0)
            {
                HP+=1;
                HP_Potion -= 1;
            }
        }

    }
}
