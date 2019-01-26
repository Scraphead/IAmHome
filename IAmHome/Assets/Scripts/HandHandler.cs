using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHandler : MonoBehaviour
{
    public GameObject HandPivot;

    public float moveSpeed = 3.0f;

    public float maxPosY = 4;
    public float maxPosX = 4;



    private Vector3 moveVector;
    
    
    void OnEnable()
    {

       
    }

    void Update()
    {
        

        GetInput();
        
    }

    private void GetInput()
    {


        if (Input.GetKey(KeyCode.I))
        {
            gameObject.transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.K))
        {
            gameObject.transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.L))
        {
            gameObject.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.J))
        {
            gameObject.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        //Vector3 clampedPosition = transform.position;

        //clampedPosition.y = Mathf.Clamp(transform.position.y, -maxPosY, maxPosY);
        //clampedPosition.x = Mathf.Clamp(transform.position.x, -maxPosX, maxPosX);


        //transform.position = clampedPosition;
    }



}

