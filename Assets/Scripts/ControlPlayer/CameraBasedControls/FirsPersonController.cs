using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]

public class FirstPersonController : MonoBehaviour
{
    // Set and give headers adjustable 
    // values that will show up in the
    // inspector and set default values
    [Header("Movement Speeds")]
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float sprintMultiplier = 2.0f;

    [Header("Jump Parameters")]
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float gravityMultiplier = 1.0f;

    [Header("Look Parameters")]
    [SerializeField] private float mouseSensitivity = 0.1f;
    [SerializeField] private float upDownLookRange = 80f;

    // Put references that show up in and can be changed in the inspector
    // With default values being defined
    [Header("References")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private PlayerInputHandler playerInputHandler;
    [SerializeField] private AnimationHandler animationHandler;

    private Vector3 currentMovement;
    private float verticalRotation;
    private float CurrentSpeed => walkSpeed * (playerInputHandler.SprintTriggered ? sprintMultiplier : 1);


    // Start is called before the first frame update
    void Start()
    {
        // Start game with locking the Cursor in the center and hiding it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Declare Booleans for Animation and possibly other stuff
        bool isGrounded = characterController.isGrounded;
        bool isMoving = playerInputHandler.MovementInput.magnitude > 0.1f;
        // Declare floats for Directional Movement Animation 
        float xMovement = playerInputHandler.MovementInput.x;
        float zMovement = playerInputHandler.MovementInput.y;



        // Call Functions each frame for First Person Movement and Rotation
        HandleMovement();
        HandleRotation();

        // Set Trigger Parameter for Animator
        if (playerInputHandler.JumpTriggered)
        {
            animationHandler.SetTrigger("Jump");
        }

        // Update Boolean Parameters in Animator
        animationHandler.UpdateMovementAnimation(
            isMoving,
            isGrounded,
            playerInputHandler.SprintTriggered
        );

        // Update Float Parameters in Animator
        animationHandler.UpdateDirectionAnimation(
            xMovement, 
            zMovement, 
            playerInputHandler.SprintTriggered
        );
    }

    private Vector3 CalculateWorldDirection()
    {
        Vector3 inputDirection = new Vector3(
            playerInputHandler.MovementInput.x, 
            0f, 
            playerInputHandler.MovementInput.y
        );

        Vector3 worldDirection = transform.TransformDirection(inputDirection);

        return worldDirection.normalized;
    }

    private void HandleJumping()
    {
        if (characterController.isGrounded)
        {
            currentMovement.y = -0.5f;

            if (playerInputHandler.JumpTriggered)
            {
                currentMovement.y = jumpForce;
            }
        }
        else 
        {
            currentMovement.y += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }
    }

    private void HandleMovement()
    {
        Vector3 worldDirection = CalculateWorldDirection();

        currentMovement.x = worldDirection.x * CurrentSpeed;
        currentMovement.z = worldDirection.z * CurrentSpeed;
        //if (CurrentSpeed >= walkSpeed && currentMovement.z > 0.5)
        //{
        //    currentMovement.x = worldDirection.x * CurrentSpeed;
        //    currentMovement.z = worldDirection.z * CurrentSpeed * 2.0f;
        //}
        //else 
        //{
        //    currentMovement.x = worldDirection.x * CurrentSpeed;
        //    currentMovement.z = worldDirection.z * CurrentSpeed;
        //}

        
        HandleJumping();
        characterController.Move(currentMovement * Time.deltaTime);
    }

    private void ApplyHorizontalRotation(float rotationAmount)
    {
        transform.Rotate(0, rotationAmount, 0);
    }

    private void ApplyVerticalRotation(float rotationAmount)
    {
        verticalRotation = Mathf.Clamp(verticalRotation - rotationAmount, -upDownLookRange, upDownLookRange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    private void HandleRotation()
    {
        float mouseXRotation = playerInputHandler.RotationInput.x * mouseSensitivity;
        float mouseYRotation = playerInputHandler.RotationInput.y * mouseSensitivity;

        ApplyHorizontalRotation(mouseXRotation);
        ApplyVerticalRotation(mouseYRotation);
    }
}

    

