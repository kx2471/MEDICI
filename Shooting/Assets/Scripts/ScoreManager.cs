using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 점수를 표현하고싶다.
// 점수가 갱신되면 UI에도 반영하고싶다.
// 적이 총알과 부딪혔을때 점수를 1점 증가시키고 싶다.

// ScoreManager로 만든 객체(컴포넌트)를 어디서든지 쉽게 접근하고싶다.
// 싱글톤 패턴으로 만들고싶다.
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;

    private void Awake()
    {
        instance = this;
    }

    // SCORE s===================================
    int score = 0;
    public Text textScore = null;

    // property : 함수인데 변수처럼 사용할 수 있다.
    public int SCORE
    {
        get { return score; }
        set
        {
            score = value;
            textScore.text = "현재점수 : " + score + "점";

            // 만약 현재점수가 최고점수보다 커지면
            if (score > highScore)
            {
                // 최고점수를 현재점수로 갱신하고싶다.
                HIGHSCORE = score;
                // 최고점수를 파일로 저장하고싶다.
                PlayerPrefs.SetInt("HIGHSCORE", score);
            }
        }
    }
    // SCORE e===================================

    // HIGHSCORE s===================================
    int highScore = 0;
    public Text textHighScore = null;

    // property : 함수인데 변수처럼 사용할 수 있다.
    public int HIGHSCORE
    {
        get { return highScore; }
        set
        {
            highScore = value;
            textHighScore.text = "최고점수 : " + highScore + "점";
        }
    }
    // HIGHSCORE e===================================

    // Start is called before the first frame update
    void Start()
    {
        // 태어날 때 점수를 0점으로 하고 UI에도 0점 이라고 표현하고싶다.
        SCORE = 0;
        // 태어날 때 최고점수 파일을 불러오고싶다.
        HIGHSCORE = PlayerPrefs.GetInt("HIGHSCORE", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
