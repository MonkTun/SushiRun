using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    [SerializeField] private GameObject wasabiShield;
    private bool isInvincible = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (isInvincible)
            {
                isInvincible = false;
                wasabiShield.SetActive(false);
                Destroy(collision.gameObject);
                SoundManager.Instance.GeneralPlaySoundEffect("WasabiPower");
                return;
            }
            
            GameManager.Instance.GameOver();
            //Debug.Log("Player Collision");
            Time.timeScale = 0;
            SoundManager.Instance.GeneralPlaySoundEffect("Death_Sound");
            //print("Collision");
        }
        else if (collision.gameObject.CompareTag("Wasabi"))
        {
            SoundManager.Instance.GeneralPlaySoundEffect("ItemGain");
            
            Destroy(collision.gameObject);
            isInvincible = true;
            wasabiShield.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("SoySauce"))
        {
            SoundManager.Instance.GeneralPlaySoundEffect("ItemGain");
            
            GameManager.Instance.score += 10;
            Destroy(collision.gameObject);
        }
    }
}