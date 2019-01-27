using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{

    public static KeyManager instance;

    public bool KeyOnDesk;
    public bool KeyOnHand;
    public bool KeyOverHead;
    public bool KeyInDoor;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

}
