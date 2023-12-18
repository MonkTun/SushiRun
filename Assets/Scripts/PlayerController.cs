using System.Data.Common;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BoxCollider2D defaultBoxCollider, crouchingBoxCollider;
    
    public float jumpSpeed = 5f;
    public bool isJumping = false;
    public bool isCrouching = false;
    private float jumpStartTime;
    public float jumpDuration = 0.5f; // Adjust this value for the duration of the jump
    public SpriteRenderer spriteRenderer;
    public PlayerLevelUp playerLevelUp;
    public float currentPosition = 5f;
    //sushi sprites
    public Sprite jumpLevel1;
    public Sprite jumpLevel2;
    public Sprite jumpLevel3;
    public Sprite jumpLevel4;
    public Sprite jumpLevel5;
    public Sprite jumpLevel6;
    public Sprite jumpLevel7;
    private Animator animator; //setting the animator
        

    private Vector2 initialPosition;
    
    bool touchInputleftJump, touchInputRightCrouch;

    void Start()
    {
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMobileInput();
        
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || touchInputleftJump) &&
            !isJumping)
        {
            FreezeRun();
            Jump();
            
            switch (playerLevelUp.level)
            {
                
                case 1:
                    spriteRenderer.sprite = jumpLevel1; break;
                case 2:
                    spriteRenderer.sprite = jumpLevel2; break;
                case 3:
                    spriteRenderer.sprite = jumpLevel3; break;
                case 4:
                    spriteRenderer.sprite = jumpLevel4; break;
                case 5:
                    spriteRenderer.sprite = jumpLevel5; break;
                case 6:
                    spriteRenderer.sprite = jumpLevel6; break;
                case 7:
                    spriteRenderer.sprite = jumpLevel7; break;
                default:
                    spriteRenderer.sprite = jumpLevel7; break;
            }
        }
        
        
        if (((Input.GetKey(KeyCode.DownArrow) || touchInputRightCrouch) && !isJumping))
        {
            //Debug.Log("Player Crouched!");
            Crouch();
            isCrouching = true;
            defaultBoxCollider.enabled = false;
            crouchingBoxCollider.enabled = true;
        }
        else
        {
            playerLevelUp.Animator.SetBool("is_sliding", false);
            isCrouching = false;
            defaultBoxCollider.enabled = true;
            crouchingBoxCollider.enabled = false;

        }

        if (isJumping)
        {
            float elapsedTime = Time.time - jumpStartTime;
            
            float jumpHeight = Mathf.Sin((elapsedTime / jumpDuration) * Mathf.PI) * jumpSpeed;

            transform.position = new Vector2(initialPosition.x, initialPosition.y + jumpHeight);

            // Check if the jump is completed
            if (elapsedTime >= jumpDuration)
            {
                isJumping = false;
                animator.enabled = true; //unfreezes te run animation
                transform.position = initialPosition; // Ensure the object is exactly at the initial position
            }
        }

        touchInputleftJump = false;
        touchInputRightCrouch = false;
    }


    void FreezeRun() //the function that freezes the running animation
    {
        animator.enabled = false;
    }
    
    void Jump()
    {
        isJumping = true;
        jumpStartTime = Time.time;
        // play jump sound
        SoundManager.Instance.GeneralPlaySoundEffect("Jump_Sound");
    }

    void Crouch()
    {
        //isCrouching = true;
        playerLevelUp.Animator.SetBool("is_sliding", true);
        //isCrouching = false;
        
    }
    
    // INPUT FOR MOBILE

    private void HandleMobileInput()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.y < Screen.height * 0.75f)
                if (touch.position.x < Screen.width * 0.5f)
                {
                    touchInputleftJump = true;
                    print("leftJump");
                }
                else
                {
                    print("rightCrouch");
                    touchInputRightCrouch = true;
                }
        }
    }


}