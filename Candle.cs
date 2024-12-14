using UnityEngine;

public class Candle : MonoBehaviour
{
    public int points = 1;

    protected virtual void Eat()
    {
        FindObjectOfType<GameManager>().CandleEaten(this);
    }    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Kalbo")){
            Eat();
        }
    }
}
