﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetRecursiveHead : MonoBehaviour
{

    public GameObject offsetReference;
    public GameObject offsetFrom;
    public GameObject offsetTo;
    public GameObject rotateOffsetTo;

    public bool invertRotate;
    
    
    public float scale; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var transformDelta = offsetFrom.transform.position - offsetReference.transform.position;
        offsetTo.transform.localPosition = transformDelta * scale;

        rotateOffsetTo.transform.localEulerAngles = offsetFrom.transform.eulerAngles;
//        if(invertRotate)
//            rotateOffsetTo.transform.rotation = Quaternion.Inverse(offsetFrom.transform.rotation);
//        else
//            rotateOffsetTo.transform.rotation = offsetFrom.transform.rotation;

    }
}
