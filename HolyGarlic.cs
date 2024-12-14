using UnityEngine;

public class HolyGarlic : Candle
{
    public float duration = 8.0f;

    protected override void Eat()
    {
        FindObjectOfType<GameManager>().HolyGarlicEaten(this);
    }    
}
