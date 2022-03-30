using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPotion : MonoBehaviour
{

   
    private void OnTriggerStay(Collider other)
    {

        
            // ���� other�� �÷��̾���
            //other.gameObject.name.Contains("Player"); �̸����κ�
            //other.gameObject.CompareTag("Player"); �±׷� ��

            if (other.gameObject.name.Contains("Player"))
            {
                PlayerHP playerHp = other.gameObject.GetComponent<PlayerHP>();
                if (playerHp != null)
                {

                playerHp.HP_Potion++;
                Destroy(gameObject);

                }
            }
        
        

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
