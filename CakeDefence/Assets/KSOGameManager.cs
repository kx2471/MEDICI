using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KSOGameManager : MonoBehaviour
{
    public static KSOGameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject GameOverUI;
    

   public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

}
