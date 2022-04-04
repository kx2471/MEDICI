using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    public Animator anim;
    public GameObject[] Fruits = new GameObject[2];

    

    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger("Picking");
            if (other.gameObject.CompareTag("Item"))
            {          

                if (other.gameObject.name.Contains("UmbrellaItem"))
                {
                    UmbrellaActive.instance.umbCount++;
                }

                if (other.gameObject.name.Contains("����"))
                {
                    KSOFruitsActive.instance.fruitcount1++;
                }
                if (other.gameObject.name.Contains("����"))
                
                    KSOFruitsActive.instance.fruitcount2++;
                }
                if (other.gameObject.name.Contains("ü��"))
                {
                    KSOFruitsActive.instance.fruitcount3++;
                }
                //ItemType itemType = other.gameObject.GetComponent<ItemType>();
                //if (itemType != null)
                //{
                //    if (itemType.type == ItemType.EItemType.����)
                //    {
                //        KSOFruitsActive.instance.fruitcount1++;
                //    }
                //    else if (itemType.type == ItemType.EItemType.����)
                //    {
                //        KSOFruitsActive.instance.fruitcount2++;
                //    }
                //    else if (itemType.type == ItemType.EItemType.ü��)
                //    {
                //        KSOFruitsActive.instance.fruitcount3++;
                //    }
                //}


                Destroy(other.gameObject);

            }

        }



        // Start is called before the first frame update
        void Start()
        {
            KSOFruitsActive.instance.fruitcount1 = 0;
            KSOFruitsActive.instance.fruitcount2 = 0;
            KSOFruitsActive.instance.fruitcount3 = 0;
            
        }

        
    }

