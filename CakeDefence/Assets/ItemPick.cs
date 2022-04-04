using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    public Animator anim;
    public GameObject[] Fruits = new GameObject[2];

    private bool isPickUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item") && isPickUp == true)
        {

            if (other.gameObject.name.Contains("UmbrellaItem"))
            {
                UmbrellaActive.instance.umbCount++;
                print(UmbrellaActive.instance.umbCount);
            }

            if (other.gameObject == Fruits[0])
            {
                KSOFruitsActive.instance.fruitcount1++;
            }
            if (other.gameObject == Fruits[1])
            {
                KSOFruitsActive.instance.fruitcount2++;
            }
            if (other.gameObject == Fruits[2])
            {
                KSOFruitsActive.instance.fruitcount3++;
            }
            Destroy(other.gameObject);
            isPickUp = false;

        }

    }



    // Start is called before the first frame update
    void Start()
    {
        KSOFruitsActive.instance.fruitcount1 = 0;
        KSOFruitsActive.instance.fruitcount2 = 0;
        KSOFruitsActive.instance.fruitcount3 = 0;
        isPickUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger("Picking");
            isPickUp = true;
        }

    }
}
