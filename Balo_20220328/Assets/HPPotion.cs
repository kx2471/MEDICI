using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPotion : MonoBehaviour
{

   
    private void OnTriggerStay(Collider other)
    {

        
            // 만약 other가 플레이어라면
            //other.gameObject.name.Contains("Player"); 이름으로비교
            //other.gameObject.CompareTag("Player"); 태그로 비교

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
