﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkRegister : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LegWalkManager.instance.legAnimators.Add(GetComponent<Animator>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
