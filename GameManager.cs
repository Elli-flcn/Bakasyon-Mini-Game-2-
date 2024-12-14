using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ghosts[] ghosts;
    public Kalbo kalbo;
    public Transform candle;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;

    public GameOverScreen gameOverScreen;

    public int ghostMultiplier { get; private set; } = 1;  
    public int score { get; private set; }
    public int lives { get; private set; }

    private bool isGameOver;

    private void Start()
    {
        NewGame();
    }   

    private void Update()
    {
    }

    private void NewGame()
    {
        isGameOver = false;

        SetScore(0);
        SetLives(3);

        ResetState();

        // Reactivate all candles
        foreach (Transform candle in candle)
        {
            candle.gameObject.SetActive(true);
        }
    }

    private void ResetState()
    {
        ResetGhostMultiplier();
        for (int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].ResetState();
        }

        this.kalbo.ResetState();
    }

    private void GameOver()
    {
        gameOverScreen.Setup(score);

        isGameOver = true;

        foreach (Ghosts ghostEntity in ghosts)
        {
            ghostEntity.gameObject.SetActive(false);
        }

        kalbo.gameObject.SetActive(false);
    }

    private void SetScore(int score)
    {
        scoreText.text = score.ToString().PadLeft(2, '0');
        this.score = score;
    }

    private void SetLives(int lives)
    {
        livesText.text = "x" + lives.ToString();
        this.lives = lives;
    }

    public void GhostEaten(Ghosts ghost)
    {
        this.ghostMultiplier++;
    }

    public void KalboEaten()
    {
        // Prevent multiple calls to this method
        if (!kalbo.gameObject.activeSelf)
            return;

        // Hide Pacman and reduce lives by 1
        kalbo.gameObject.SetActive(false);
        SetLives(this.lives - 1);

        if (this.lives > 0)
        {
            Invoke(nameof(ResetState), 3.0f);
        }
        else
        {
            GameOver();
        }
    }

    public void CandleEaten(Candle candle)
    {
        candle.gameObject.SetActive(false);
        SetScore(this.score + candle.points);
    }

    public void HolyGarlicEaten(HolyGarlic candle)
    {
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].frightened.Enable(candle.duration);
        }

        CandleEaten(candle);
        CancelInvoke();
        Invoke(nameof(ResetGhostMultiplier), candle.duration);
    }

    private bool HasRemainingCandle()
    {
        foreach (Transform candle in this.candle) {
            if (candle.gameObject.activeSelf) {
                return true;
            }
        }

        return false;
    }

    private void ResetGhostMultiplier()
    {
        this.ghostMultiplier = 1;
    }
}
