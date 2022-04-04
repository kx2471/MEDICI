using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// �¾ �� GameOverUI�� ��Ȱ��ȭ �ϰ�ʹ�.
// �÷��̾ �ı��ɶ� GameOverUI�� Ȱ��ȭ �ϰ�ʹ�.
// Restart, Quit ��ư�� ���������� ȣ��� �Լ��� �����ϰ�ʹ�.
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject GameOverUI = null;
    // Start is called before the first frame update
    void Start()
    {
        // �¾ �� GameOverUI�� ��Ȱ��ȭ �ϰ�ʹ�.
        GameOverUI.SetActive(false);
    }

    // Restart, Quit ��ư�� ���������� ȣ��� �Լ��� �����ϰ�ʹ�.
    public void OnClickRestart()
    {
        print("OnClickRestart");
        // ����Scene�� �ٽ� �ε��ϰ�ʹ�.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickQuit()
    {
        print("OnClickQuit");
        Application.Quit();
    }
}
