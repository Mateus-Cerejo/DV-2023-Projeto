using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    private Vector3 move;
    private Vector3 velocity;
    [SerializeField] private ArtifactBackPack abp;
    [SerializeField] private float runningSpeed = 6.0f;

    [SerializeField] private float sprintSpeedMultiplier = 2.0f;
    [SerializeField] private float maxSprintValue = 10.0f;
    private float currentSprintValue = 0.0f;
    private bool tired = false;
    [SerializeField] private float sprintDecrement = 1.0f;
    [SerializeField] private float sprintIncrement = 1.0f;
    [SerializeField] private Image sprintBar;

    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isGrounded;

    [SerializeField] private float jumpHeight = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        runningSpeed *= PlayerPrefs.GetFloat("speedBonus", 1);
        currentSprintValue = maxSprintValue;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        // Determine movement speed based on sprinting or normal running
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) && isGrounded && currentSprintValue > 0 && !tired
            ? runningSpeed * sprintSpeedMultiplier + runningSpeed * abp.speedArtifactQuantityEquiped * abp.speedArtifactEffect + runningSpeed * abp.allInOneArtifactQuantityEquiped * abp.allInOneArtifactEffect
            : runningSpeed + runningSpeed * abp.speedArtifactQuantityEquiped * abp.speedArtifactEffect + runningSpeed * abp.allInOneArtifactQuantityEquiped * abp.allInOneArtifactEffect;

        controller.Move(move * currentSpeed * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftShift)&&isGrounded&&currentSprintValue>0&&!tired&&move.magnitude>0){
            currentSprintValue -= sprintDecrement * Time.deltaTime;
            if(currentSprintValue<=0) tired = true;
        }else{
            currentSprintValue += sprintIncrement * Time.deltaTime;
            if(currentSprintValue>=maxSprintValue)
            {
                tired=false;
                currentSprintValue = maxSprintValue;
            }
        }

        if(isGrounded && velocity.y<0)
        {
            velocity.y = -9.81f;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight*-2f*gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        sprintBar.fillAmount = currentSprintValue/maxSprintValue;
    }
}
