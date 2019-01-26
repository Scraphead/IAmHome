using UnityEngine;
using System.Collections;

// The GameObject is made to bounce using the space key.
// Also the GameOject can be moved forward/backward and left/right.
// Add a Quad to the scene so this GameObject can collider with a floor.

public class CharacterMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float bodyRotateSpeed = 20;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    public float cameraSpeed = 50f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    public GameObject cameraRotate;
    public GameObject bodyRotate;
    

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // let the gameObject fall down
//        gameObject.transform.position = new Vector3(0, 5, 0);
    }

    void Update()
    {
//
//        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
//        moveDirection = transform.TransformDirection(moveDirection);
//        moveDirection = moveDirection * speed;



        var cameraEuler = cameraRotate.transform.localEulerAngles;
        cameraRotate.transform.localEulerAngles = new Vector3(
            cameraEuler.x + (Input.GetAxisRaw("Mouse Y") * cameraSpeed * Time.deltaTime),
//            Mathf.Clamp(cameraEuler.x + (Input.GetAxisRaw("Mouse Y") * cameraSpeed * Time.deltaTime),-89, 89),
            cameraEuler.y + (Input.GetAxisRaw("Mouse X") * cameraSpeed * Time.deltaTime),
            cameraEuler.z);
//        cameraRotate.transform.Rotate(Vector3.left, Input.GetAxisRaw("Mouse Y") * cameraSpeed * Time.deltaTime);
//        cameraRotate.transform.Rotate(Vector3.up, ;

        var projectedXZplaneForward = Vector3.ProjectOnPlane(cameraRotate.transform.forward, Vector3.up);
        var forwardMovement = projectedXZplaneForward.normalized * Input.GetAxis("Vertical");
        
        var projectedXZplaneLeft = Vector3.ProjectOnPlane(cameraRotate.transform.right, Vector3.up);
        var leftMovement = projectedXZplaneLeft.normalized * Input.GetAxis("Horizontal");

        moveDirection = (forwardMovement + leftMovement)* speed;

        var bodyEuler = bodyRotate.transform.localEulerAngles;
        
        bodyRotate.transform.localEulerAngles = new Vector3(bodyEuler.x, bodyEuler.y + Input.GetAxisRaw("RotateBody") * bodyRotateSpeed, bodyEuler.x);
        
        
        
        
        if (Input.GetButton("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}