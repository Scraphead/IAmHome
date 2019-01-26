using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetRecursive : MonoBehaviour
{

    public GameObject offsetFrom;
    public GameObject offsetTo;
    public GameObject rotateOffsetTo;
    public bool invertRotate;
    
//    public GameObject offsetFromHead;
//    public GameObject offsetToHead;
    
    public float scale; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offsetTo.transform.localPosition = offsetFrom.transform.position * scale;
        if(invertRotate)
            rotateOffsetTo.transform.rotation = Quaternion.Inverse(offsetFrom.transform.rotation);
        else
            rotateOffsetTo.transform.rotation = offsetFrom.transform.rotation;

    }
}
