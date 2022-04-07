using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJE_FruitsMove : MonoBehaviour
{
    enum State
    {
        
        Hang,
        Drop,
        Free,
    }
    State state;
    Rigidbody rigid;

    public AudioClip audioContact;
    public AudioClip audioDrop;
    AudioSource audioSource;

    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }


    void PlaySound(string action)
    {
        switch (action)
        {
            case "Contact":
                audioSource.clip = audioContact;
                break;
            case "Drop":
                audioSource.clip = audioDrop;
                break;
        }
        audioSource.Play();
    }
    

    // Start is called before the first frame update
    void Start()
    {
        state = State.Hang;
        rigid = GetComponent<Rigidbody>();
        if (rigid == null)
        {
            rigid = gameObject.AddComponent<Rigidbody>();
        }
        rigid.useGravity = true;
        rigid.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (state)
        {
            case State.Hang:
                if (collision.gameObject.name.Contains("Player") ||
                    collision.gameObject.name.Contains("Bullet"))
                {
                    print("bulletcollision");
                    transform.parent = null;
                    rigid.isKinematic = false;
                    state = State.Drop;
                    PlaySound("Contact");
                }
                break;

            
                

            case State.Drop:
                if (collision.gameObject.CompareTag("Ground"))
                {
                    GetComponent<Collider>().isTrigger = true;
                    Destroy(rigid);
                    state = State.Free;
                    PlaySound("Drop");
                    
                }
                break;
                
        }
        
    }
}
