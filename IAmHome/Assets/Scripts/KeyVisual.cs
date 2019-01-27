using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyVisual : MonoBehaviour
{
    public KeyPlacement keyPlacement;
    private KeyManager keyManager;
    public GameObject keyObject;
    
    // Start is called before the first frame update
    void Start()
    {
        keyManager = KeyManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        switch (keyPlacement)
        {
            case KeyPlacement.Desk:
                keyObject.SetActive(keyManager.KeyOnDesk);
                break;
            case KeyPlacement.Hand:
                keyObject.SetActive(keyManager.KeyOnHand);
                break;
            case KeyPlacement.Floor:
                keyObject.SetActive(keyManager.KeyOnFloor);
                break;
            case KeyPlacement.AboveHead:
                keyObject.SetActive(keyManager.KeyOverHead);
                break;
            case KeyPlacement.Door:
                keyObject.SetActive(keyManager.KeyInDoor);
                break;
        }
    }
}

public enum KeyPlacement
{
    Desk,
    Hand,
    Floor,
    AboveHead,
    Door,
}
