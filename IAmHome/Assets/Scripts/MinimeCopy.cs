using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimeCopy : MonoBehaviour
{
    public GameObject bodyFrom;
    public GameObject bodyTo;
    public GameObject headFrom;
    public GameObject headTo;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bodyTo.transform.localPosition = bodyFrom.transform.position;
        bodyTo.transform.localRotation = bodyFrom.transform.rotation; 
        
        headTo.transform.localPosition = headFrom.transform.position;
        headTo.transform.localRotation = headFrom.transform.rotation;
    }
}
