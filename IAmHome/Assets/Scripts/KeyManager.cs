using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{

    public static KeyManager instance;

    public bool KeyOnDesk;
    public bool KeyOnHand;
    public bool KeyOnFloor;
    public bool KeyOverHead;
    public bool KeyInDoor;

    public AudioSource keyMove;
    public AudioSource doorUnlock;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Update()
    {
        if (Input.GetKey("1"))
        {
            DisableAllKeys();
            KeyOnDesk = true;
            PlayKey();
            HandCloseManager.instance.OpenHand();
        }
        if (Input.GetKey("2"))
        {
            DisableAllKeys();
            KeyOnHand = true;
            PlayKey();
            HandCloseManager.instance.CloseHand();
        }
        if (Input.GetKey("3"))
        {
            DisableAllKeys();
            KeyOnFloor = true;
            PlayKey();
            HandCloseManager.instance.OpenHand();
        }
        if (Input.GetKey("4"))
        {
            DisableAllKeys();
            KeyOverHead = true;
            PlayKey();
            HandCloseManager.instance.OpenHand();
        }
        if (Input.GetKey("5"))
        {
            DisableAllKeys();
            KeyInDoor = true;
            if(!doorUnlock.isPlaying)
                doorUnlock.Play();
            HandCloseManager.instance.OpenHand();
        }
    }

    public void PlayKey()
    {
        if(!keyMove.isPlaying)
            keyMove.Play();  
    }
    private void DisableAllKeys()
    {
        KeyOnDesk = false;
        KeyOnHand = false;
        KeyOnFloor = false;
        KeyOverHead = false;
        KeyInDoor = false;
    }
    
    
}
