using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeed = 5f;
    public bool isJumping = false;
    private float jumpStartTime;
    public float jumpDuration = 0.5f; // Adjust this value for the duration of the jump

    private Vector2 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !isJumping)
        {
            Debug.Log("Player Jumped!");
            Jump();
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
}