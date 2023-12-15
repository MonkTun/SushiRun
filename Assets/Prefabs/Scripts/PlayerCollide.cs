using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    private bool isInvincible = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (isInvincible)
            {
                isInvincible = false;
                Destroy(collision.gameObject);
                return;
            }
            
            GameManager.Instance.GameOver();
            Debug.Log("Player Collision");
            Time.timeScale = 0;
            SoundManager.Instance.GeneralPlaySoundEffect("Death_Sound");
            print("Collision");
        }
        else if (collision.gameObject.CompareTag("Wasabi"))
        {
            Debug.LogWarning("powerup");
            Destroy(collision.gameObject);
            isInvincible = true;
        }
        else if (collision.gameObject.CompareTag("SoySauce"))
        {
            GameManager.Instance.score += 10;
            Destroy(collision.gameObject);
        }
    }
}