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
        }
        if (Input.GetKey("2"))
        {
            DisableAllKeys();
            KeyOnHand = true;
        }
        if (Input.GetKey("3"))
        {
            DisableAllKeys();
            KeyOnFloor = true;
        }
        if (Input.GetKey("4"))
        {
            DisableAllKeys();
            KeyOverHead = true;
        }
        if (Input.GetKey("5"))
        {
            DisableAllKeys();
            KeyInDoor = true;
        }
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
