using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeed = 5f;
    public bool isJumping = false;
    public bool isCrouching = false;
    private float jumpStartTime;
    public float jumpDuration = 0.5f; // Adjust this value for the duration of the jump


    private Vector2 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !isJumping && !isCrouching)
        {
            Debug.Log("Player Jumped!");
            Jump();
        }
        
        
        if (((Input.GetMouseButton(1) || Input.GetKey(KeyCode.DownArrow)) && !isJumping && !isCrouching))
        {
            Debug.Log("Player Crouched!");
            Crouch();
        }
        else
        {
            transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
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
                transform.position = initialPosition; // Ensure the object is exactly at the initial position
            }
        }
    }

    void Jump()
    {
        isJumping = true;
        jumpStartTime = Time.time;
    }

    void Crouch()
    {
        isCrouching = true;
        transform.localScale = new Vector3(3.0f, 2.0f, 3.0f);
        isCrouching = false;
        
        
    }
}