using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HandCloseManager.instance.handAnimators.Add(GetComponent<Animator>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
