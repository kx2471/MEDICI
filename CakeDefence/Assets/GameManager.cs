using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject menuSet;
    public GameObject EndUI;
    public GameObject finalFlame;
    public GameObject playMenuCanvas;
    public GameObject Candle;
    public GameObject GameOverUI;
    public GameObject HowToPlay;
    public GameObject AudioManager;
    public GameObject mainCamera;
    public Transform miniCamera;
    public Transform sideCamera;

    float currentTime;
    float createTime = 5;


    bool isPause;


    private void Start()
    {

        currentTime = 0;
        isPause = false;
    }



    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
                if (isPause == true)
                {
                    Time.timeScale = 1;
                    isPause = false;
                    return;
                }
            }
            else
            {
                menuSet.SetActive(true);
                if (isPause == false)
                {
                    Time.timeScale = 0;
                    isPause = true;
                    return;
                }
            }
        }
        if (finalFlame.activeSelf == true)
        {


            print("END!!");
            mainCamera.transform.position = sideCamera.transform.position;
            mainCamera.transform.rotation = sideCamera.transform.rotation;



            currentTime += Time.deltaTime;
            if (currentTime > createTime)
            {
                mainCamera.transform.position = miniCamera.transform.position;
                mainCamera.transform.rotation = miniCamera.transform.rotation;
            }


            playMenuCanvas.SetActive(false);
            StartCoroutine("EndUIPopUp", 10);
        }
    }



    IEnumerator EndUIPopUp(float num)
    {
        yield return new WaitForSeconds(num);

        EndUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        if (menuSet.activeSelf)
        {
            menuSet.SetActive(false);

            if (isPause == true)
            {
                Time.timeScale = 1;
                isPause = false;
                return;
            }
        }
    }

    public void HomeButton()
    {

        menuSet.SetActive(false);
        if (isPause == true)
        {
            Time.timeScale = 1;
            isPause = false;
            return;
        }

        else
        {
            menuSet.SetActive(true);
            if (isPause == false)
            {
                Time.timeScale = 0;
                isPause = true;
                return;
            }

        }
    }


    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }



    public void Ending()
    {
        Candle.SetActive(true);
        print("Candle");


    }


    public void AudioMenu()
    {
        if (AudioManager.activeSelf == true)
        {
            AudioManager.SetActive(false);
        }
        else
        {
            AudioManager.SetActive(true);
        }
    }

    public void returnMenu()
    {
        if (HowToPlay.activeSelf == true)
        {
            HowToPlay.SetActive(false);
            menuSet.SetActive(true);
        }
    }

    public void OnClickHowtoPlay()
    {
        menuSet.SetActive(false);
        HowToPlay.SetActive(true);
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void OnClickExit()
    {
        Application.Quit();
    }


    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

}