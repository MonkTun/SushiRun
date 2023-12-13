using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text displayText;
    public string obstacleTag = "Obstacle";
    private float count = 0f;
    private bool counting = true;

    public float checkCollisionRadius = 1;
    public float scoreMultiplier = 3.0f; // Adjust this value to change the speed of counting

    void Update()
    {
        if (counting)
        {
            count += Time.deltaTime * scoreMultiplier; // Adjust the multiplier to change the counting speed
            displayText.text = Mathf.FloorToInt(count).ToString();
        }

        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, checkCollisionRadius);

        foreach (Collider2D col in cols)
        {
            if (col.CompareTag(obstacleTag))
            {
                counting = false;
                Debug.Log("Counting stopped on collision with obstacle.");
            }
        }
    }
}