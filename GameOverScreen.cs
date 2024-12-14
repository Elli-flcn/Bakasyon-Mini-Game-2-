using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;

    public void Setup(int score) {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " ";
    }

    public void YesButton() {
        SceneManager.LoadScene("Mini Game #2");
    }

    public void NoButton() {
        SceneManager.LoadScene("Main Menu");
    }
}
