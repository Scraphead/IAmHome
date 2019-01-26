using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHandler : MonoBehaviour
{
    public int playerId = 0;

    public float moveSpeed = 3.0f;
   
  

    private CharacterController cc;
    private Vector3 moveVector;
    
    
    void OnEnable()
    {
      
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        

        GetInput();
        ProcessInput();
    }

    private void GetInput()
    {
      

        //moveVector.x = Input.GetKeyDown(KeyCode.L); 
        //moveVector.y = GetAxis("MoveHandVertical");
     
    }

    private void ProcessInput()
    {
      
        if (moveVector.x != 0.0f || moveVector.y != 0.0f)
        {
            cc.Move(moveVector * moveSpeed * Time.deltaTime);
        }

       
    }
}

