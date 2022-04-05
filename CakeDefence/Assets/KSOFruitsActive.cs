using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KSOFruitsActive : MonoBehaviour
{
    public static KSOFruitsActive instance;
    private void Awake()
    {
        instance = this;
    }

    public int fruitcount1;
    public int fruitcount2;
    public int fruitcount3;
    public Text grapesText;
    public Text strawberryText;
    public Text cherryText;
    public Animator anim;

    public GameObject putPosition;
    public GameObject[] fruitsFactory = new GameObject[2]; 

    // Start is called before the first frame update
    void Start()
    {
        fruitcount1 = 0;
        fruitcount2 = 0;
        fruitcount3 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        grapesText.text = "X" + fruitcount1;
        strawberryText.text = "X" + fruitcount2;
        cherryText.text = "X" + fruitcount3;


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("Picking");
            if (fruitcount1 > 0)
            {
                GameObject fruits = Instantiate(fruitsFactory[0]);
                fruits.transform.position = putPosition.transform.position;
                fruitcount1--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("Picking");
            if (fruitcount2 > 0)
            {
                GameObject fruits = Instantiate(fruitsFactory[1]);
                fruits.transform.position = putPosition.transform.position;
                fruitcount2--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetTrigger("Picking");
            if (fruitcount3 > 0)
            {
                GameObject fruits = Instantiate(fruitsFactory[2]);
                fruits.transform.position = putPosition.transform.position;
                fruitcount3--;
            }

        }

    }

   
}
