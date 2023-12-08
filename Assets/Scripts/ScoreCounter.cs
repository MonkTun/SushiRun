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

    void Update()
    {
        if (counting)
        {
            count += Time.deltaTime;
            displayText.text = "Count: " + Mathf.FloorToInt(count).ToString();
        }

        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, checkCollisionRadius);

        foreach (Collider2D col in cols)
        {
            if (col.CompareTag("Obstacle"))
            {
                counting = false;
                Debug.Log("Counting stopped on collision with obstacle.");
            }
        }
    }
}
