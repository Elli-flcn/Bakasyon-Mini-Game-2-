using UnityEngine;
using UnityEngine.Events;

public class DetectorColl : MonoBehaviour
{
    [SerializeField]
    private string colliderScript;

    [SerializeField]
    private UnityEvent collisionEntered;

    private int candleCount = 0; // Tracks the number of candles collected
    private const int candlesRequired = 5; // Number of candles needed to open the door

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the correct tag
        if (collision.CompareTag("Candle"))
        {
            candleCount++; // Increment the count
            Destroy(collision.gameObject); // Destroy the collected object

            // If enough objects have been collected, trigger the event
            if (candleCount >= candlesRequired)
            {
                collisionEntered?.Invoke();
            }
        }
    }
}
