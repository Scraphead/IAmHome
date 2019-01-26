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

    public GameObject cameraRotateY;
    public GameObject cameraRotateX;
    private float cameraRotateXAngle = 0;
    public GameObject cameraOffsetTilt;
    
    public float cameraTiltDistanceOffsetMultiplierZ = 0.004f;
    public float cameraTiltDistanceOffsetMultiplierY = -0.001f;
    public float tiltUpRange = -88f;
    public float tiltDownRange = 120f;
    
    public GameObject bodyRotate;

    private float currentFallSpeed = 0;
    

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


        var cameraEuler = cameraRotateY.transform.localEulerAngles;
        cameraRotateY.transform.localEulerAngles = new Vector3(
            cameraEuler.x,
            cameraEuler.y + (Input.GetAxisRaw("Mouse X") * cameraSpeed * Time.deltaTime),
            cameraEuler.z);

        cameraRotateXAngle = cameraRotateXAngle + Input.GetAxisRaw("Mouse Y") * cameraSpeed * Time.deltaTime * -1;
        cameraRotateXAngle = Mathf.Clamp(cameraRotateXAngle, tiltUpRange, tiltDownRange);
        cameraRotateX.transform.localEulerAngles = new Vector3(cameraRotateXAngle,0,0);

        var projectedXZplaneForward = Vector3.ProjectOnPlane(cameraRotateY.transform.forward, Vector3.up);
        var forwardMovement = projectedXZplaneForward.normalized * Input.GetAxis("Vertical");

        var projectedXZplaneLeft = Vector3.ProjectOnPlane(cameraRotateY.transform.right, Vector3.up);
        var leftMovement = projectedXZplaneLeft.normalized * Input.GetAxis("Horizontal");

        moveDirection = (forwardMovement + leftMovement) * speed;

        
        
        cameraOffsetTilt.transform.localPosition = new Vector3(
            0,
            Mathf.Max(cameraRotateXAngle, 0) * cameraTiltDistanceOffsetMultiplierY,
            Mathf.Max(cameraRotateXAngle, 0) * cameraTiltDistanceOffsetMultiplierZ);

        var bodyEuler = bodyRotate.transform.localEulerAngles;

        bodyRotate.transform.localEulerAngles = new Vector3(bodyEuler.x,
            bodyEuler.y + Input.GetAxisRaw("RotateBody") * bodyRotateSpeed, bodyEuler.x);


        if (controller.isGrounded)
        {
            currentFallSpeed = 0;
        }
        if (Input.GetButton("Jump") && controller.isGrounded)
        {
            currentFallSpeed = jumpSpeed;
//            moveDirection.y = jumpSpeed;
        }
        
       

        // Apply gravity
        moveDirection.y = moveDirection.y + currentFallSpeed;

        currentFallSpeed = currentFallSpeed - (gravity * Time.deltaTime);
        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}