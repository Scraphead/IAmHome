using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegWalkManager : MonoBehaviour
{
    public static LegWalkManager instance;
    
    public List<Animator> legAnimators;

    private void Awake()
    {
        instance = this;
    }

    public void StartWalk()
    {
        foreach (var leg in legAnimators)
        {
            leg.SetBool("b_walk", true);
            leg.SetBool("b_idle", false);
//            hand.ResetTrigger("Relaxed");
//            hand.SetTrigger("Grab_key");
        }
//        Invoke("OpenHand", 1f);
        
    }

    public void StopWalk()
    {
        foreach (var leg in legAnimators)
        {
            leg.SetBool("b_walk", false);
            leg.SetBool("b_idle", true);
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
