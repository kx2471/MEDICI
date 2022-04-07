using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UmbrellaActive : MonoBehaviour
{
    public static UmbrellaActive instance;
    private void Awake()
    {
        instance = this;
    }


    public GameObject Umbrella;
    public int umbCount;
    public Text umbText;

    // Start is called before the first frame update
    void Start()
    {
        umbCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (umbCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                if (Umbrella.activeSelf == false)
                {
                    Umbrella.SetActive(true);
                }

                else
                {
                    Umbrella.SetActive(false);
                    umbCount--;
                }
            }
        }
        umbText.text = "X" + umbCount;

    }
}
