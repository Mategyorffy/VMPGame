using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    private bool jump;
    private bool crouch = false;
    public static bool gameIsPaused = false;

    [SerializeField] private LevelManager manager;
    [SerializeField] private CharacterController2D controller;

    public Camera Maincam;
    public SpriteRenderer pImage;
    public Animator pAnimator;
    public float fallMultiplier;
    public float speed = 5;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Vector3 CharacterResetPoint;


    public CheckPoint[] CheckPoints;
    private int checkPointIndex;

    private Vector2 vecGravity;

    private void Start()
    {
        checkPointIndex = 0;
        Maincam.transform.position = this.transform.position;
        vecGravity = new Vector2(0, Physics2D.gravity.y);
    }
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButton("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            Debug.Log("Crouching");
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            Debug.Log("Crouching not anymore");
            crouch = false;
        }
        if(rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
        if (Input.GetButton("Pause"))
        {
            PauseGame();
        }
    }

    private void FixedUpdate()
    {
        

        controller.Move(horizontal * Time.fixedDeltaTime, crouch, jump);
        jump = false;

       if (Input.GetKey(KeyCode.A) && IsGrounded() || Input.GetKey(KeyCode.D) && IsGrounded())
       {
      
      
           pAnimator.SetBool("Run", true);
      
      
      
      
       }
       else
       {
           pAnimator.SetBool("Run", false);
      
       }
      
        if (IsGrounded())
        {
            CharacterResetPoint = transform.position;
        }



       




    }
    private void OnGUI()
    {
    
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == CheckPoints[checkPointIndex].gameObject.name)
        {
            CheckPoints[checkPointIndex].Test();
            Debug.Log("CheckPoint!!");
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        

        if (collision.gameObject.layer == 7)
        {
            Debug.Log("Transission");
            
            manager.RelocatePlayer(collision.gameObject.GetComponent<LTpoint>().whereToTransission);
            

        }
        if(collision.gameObject.layer == 8)
        {
            transform.position = CharacterResetPoint;
        }
      
    }
    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0.01f;
            gameIsPaused = false;
        }
        else
        {
            Time.timeScale = 1;
            gameIsPaused = true;
        }
    }

}
