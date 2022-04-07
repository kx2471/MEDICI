using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour

{
    [SerializeField] private float secondPerRealTimeSecond; // ���� ������ 100�� = ���� ������ 1��

    private bool isNight = false;

    [SerializeField] private float fogDensityCalc; //������ ����

    [SerializeField] private float nightFogDensity; // �� ������ Fog �е�
    private float dayFogDensity; // �������� fog�е�
    private float currentFogDensity; // ���
    // Start is called before the first frame update
    void Start()
    {
        dayFogDensity = RenderSettings.fogDensity;
        RenderSettings.skybox = daylight;
    }
    public GameObject flame1;

    public Material night;
    public Material daylight;
    // Update is called once per frame
    void Update()
    {
        if (true == flame1.activeSelf)
        {
            print("activeSelf");
            transform.Rotate(Vector3.right, 0.1f * secondPerRealTimeSecond * 200 * Time.deltaTime);

            if (transform.eulerAngles.x >= 170)
            {
                RenderSettings.skybox = night;
                isNight = true;

            }
            else if (transform.eulerAngles.x >= 340)
            {
                RenderSettings.skybox = daylight;

                isNight = false;
            }


            if (isNight)
            {
                if (currentFogDensity <= nightFogDensity)

                {
                    currentFogDensity += 0.1f * fogDensityCalc * Time.deltaTime;
                    RenderSettings.fogDensity = currentFogDensity;

                }
            }
            else
            {
                if (currentFogDensity >= dayFogDensity)
                {
                    currentFogDensity -= 0.1f * fogDensityCalc * Time.deltaTime;
                    RenderSettings.fogDensity = currentFogDensity;

                }

            }
        }

        else if (false == flame1.activeSelf)
        {
            return;
        }
    }
}