using System.Data.Common;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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

    void Start()
    {
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
      
        if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !isJumping && !isCrouching && playerLevelUp.Level == 1)
        {
            FreezeRun();
            print("player jumped");
            Jump();
            spriteRenderer.sprite = jumpLevel1;
        }
        else if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !isJumping && !isCrouching && playerLevelUp.Level == 2)
        {
            FreezeRun();
            Jump();
            spriteRenderer.sprite = jumpLevel2;
        }
        else if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !isJumping && !isCrouching && playerLevelUp.Level == 3)
        {
            FreezeRun();
            Jump();
            spriteRenderer.sprite = jumpLevel3;
            
        }
        else if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !isJumping && !isCrouching && playerLevelUp.Level == 4)
        {
            FreezeRun();
            Jump();
            spriteRenderer.sprite = jumpLevel4;
        }
        else if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !isJumping && !isCrouching && playerLevelUp.Level == 5)
        {
            FreezeRun();
            Jump();
            spriteRenderer.sprite = jumpLevel5;
        }
        else if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !isJumping && !isCrouching && playerLevelUp.Level == 6)
        {
            FreezeRun();
            Jump();
            spriteRenderer.sprite = jumpLevel6;
            
        }
        else if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !isJumping && !isCrouching && playerLevelUp.Level == 7)
        {
            FreezeRun();
            Jump();
            spriteRenderer.sprite = jumpLevel7;
            
        }

        if (((Input.GetMouseButton(1) || Input.GetKey(KeyCode.DownArrow)) && !isJumping && !isCrouching))
        {
            Debug.Log("Player Crouched!");
            Crouch();
        }
        else
        {
            playerLevelUp.Animator.SetBool("is_sliding", false);
            

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
        isCrouching = true;
        playerLevelUp.Animator.SetBool("is_sliding", true);
        isCrouching = false;
        
    }
}