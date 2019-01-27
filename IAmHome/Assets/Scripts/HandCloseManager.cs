using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCloseManager : MonoBehaviour
{
    public static HandCloseManager instance;
    
    public List<Animator> handAnimators;

    private void Awake()
    {
        instance = this;
    }

    public void CloseHand()
    {
        foreach (var hand in handAnimators)
        {
            hand.ResetTrigger("Relaxed");
            hand.SetTrigger("Grab_key");
        }
//        Invoke("OpenHand", 1f);
        
    }

    public void OpenHand()
    {
        foreach (var hand in handAnimators)
        {
            hand.ResetTrigger("Grab_key");
            hand.SetTrigger("Relaxed");
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
