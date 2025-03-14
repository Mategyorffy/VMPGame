using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [Header("Must Assign")]
    [SerializeField] private PlayerInput Input;
    [SerializeField] private Rigidbody2D RB;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;


    //Private variable
    float Horizontal;
    bool IsFacingRight = true;


    [Header("Settings")]
    public float MoveSpeed;
    public float jumpPower;




    private void Start()
    {
       

    }
    private void FixedUpdate()
    {
        Flip();
        RB.velocity = new Vector2(Horizontal * MoveSpeed , RB.velocity.y);
    }
    public void OnMoveInputAction(InputAction.CallbackContext context)
    {
        Horizontal = context.ReadValue<Vector2>().x;
    }
    
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.transform.position,0.2f,GroundLayer);
    }

    private void Flip()
    {
        if(IsFacingRight && Horizontal < 0f || !IsFacingRight && Horizontal > 0f)
        {
            IsFacingRight = !IsFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
