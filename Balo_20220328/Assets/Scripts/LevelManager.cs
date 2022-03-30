using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private void Awake()
    {
        instance = this;
    }

    public int maxCreateCount;
    int level;
    public Text textLevel;
    public int createCount;

    public int Level
    {
        get { return level; }
        set
        {
            level = value;
            maxCreateCount = level;
            textLevel.text = "Lv " + level;
            sliderKillCount.maxValue = level;
            sliderKillCount.value = killCount;
            createCount = 0;
        }
    }

    int killCount;
    public Slider sliderKillCount;
    public Text textKillCountPer;
    public int KillCount
    {
        get { return killCount; }
        set
        {
            killCount = value;
            textKillCountPer.text = ((float)killCount / maxCreateCount * 100f) + "%";
            // 만약 killCount가 maxCreateCount이상이면
            while (killCount >= maxCreateCount)
            {
                killCount -= maxCreateCount;
                // 레벨을 1 증가시키고싶다.
                Level++;
            }

            sliderKillCount.value = killCount;
        }
    }



    public bool CanCreatEnemy()
    {
        return createCount < maxCreateCount;
    }

    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
        KillCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}


