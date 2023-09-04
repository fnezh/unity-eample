using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Health healthbar;


    public float speed = 6f;
    public float runSpeed = 10f;
    public float turnSmoothTime = 0.1f;

    public float gravity = -9f;

    //stats
    public int maxHealth = 100;
    public int maxStamine = 100;


    public int currentHealth;
    public int currentStam;


    float turnSmoothVelocity;
    public Animator animator;
    Vector3 moveVelocity;
    Vector3 turnVelocity;
   // [HideInInspector] public StaminaController _staminacontroller;

    
    void Start()
    {

        //_staminacontroller = GetComponent<StaminaController>;

        controller = GetComponent<CharacterController>();
        currentHealth = maxHealth;
        Cursor.lockState = CursorLockMode.Locked;
        healthbar.SetMaxHealth(maxHealth);
    }



/// <summary>
   // public void SetRunSpeed(float n_speed)
   // {
   //     speed = n_speed;
  //  }

/// 
/// </summary>


    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        if(controller.isGrounded)
        {
            if (direction.magnitude >= 0.1f)
            {
                
                animator.SetBool("isRunning", true);
                 
                
                float trgetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, trgetAngle, ref turnSmoothVelocity, turnSmoothTime);

                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, trgetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("isRunning", false);
                
            }
        }

        moveVelocity.y += gravity * Time.deltaTime;
        controller.Move(moveVelocity * Time.deltaTime);

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
    }

}
