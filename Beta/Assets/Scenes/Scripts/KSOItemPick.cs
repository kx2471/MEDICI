using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSOItemPick : MonoBehaviour
{
    public Animator anim;
    AudioSource audio;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Vector3 p1 = transform.position + Vector3.up * transform.localScale.y * 0.5f;
            Vector3 p2 = transform.position + Vector3.down * transform.localScale.y * 0.5f;
            float radius = transform.localScale.x * 0.5f;

            Collider[] cols = Physics.OverlapCapsule(p1, p2, radius);
            if (cols.Length > 0)
            {
                anim.SetTrigger("Picking");
                audio = GetComponent<AudioSource>();
                audio.Play();
                for (int i = 0; i < cols.Length; i++)
                {
                    Collider other = cols[i];
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
                        else if (other.gameObject.name.Contains("����"))
                        {
                            KSOFruitsActive.instance.fruitcount2++;
                        }
                        else if (other.gameObject.name.Contains("ü��"))
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
            }




        }

        //private void OnTriggerStay(Collider other)
        //{

        //    if (Input.GetKeyDown(KeyCode.Z))
        //    {
        //        anim.SetTrigger("Picking");
        //        if (other.gameObject.CompareTag("Item"))
        //        {

        //            print("PICK!!  " + other.name + ", " + gameObject.name);
        //            if (other.gameObject.name.Contains("UmbrellaItem"))
        //            {
        //                UmbrellaActive.instance.umbCount++;
        //            }

        //            if (other.gameObject.name.Contains("����"))
        //            {
        //                KSOFruitsActive.instance.fruitcount1++;
        //            }
        //            else if (other.gameObject.name.Contains("����"))
        //            {
        //                KSOFruitsActive.instance.fruitcount2++;
        //            }
        //            else if (other.gameObject.name.Contains("ü��"))
        //            {
        //                KSOFruitsActive.instance.fruitcount3++;
        //            }
        //            //ItemType itemType = other.gameObject.GetComponent<ItemType>();
        //            //if (itemType != null)
        //            //{
        //            //    if (itemType.type == ItemType.EItemType.����)
        //            //    {
        //            //        KSOFruitsActive.instance.fruitcount1++;
        //            //    }
        //            //    else if (itemType.type == ItemType.EItemType.����)
        //            //    {
        //            //        KSOFruitsActive.instance.fruitcount2++;
        //            //    }
        //            //    else if (itemType.type == ItemType.EItemType.ü��)
        //            //    {
        //            //        KSOFruitsActive.instance.fruitcount3++;
        //            //    }
        //            //}


        //            Destroy(other.gameObject);

        //        }

        //    }


        //}

        // Start is called before the first frame update
   

    }
}

