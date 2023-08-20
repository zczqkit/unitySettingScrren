using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// The function is adapated from https://www.youtube.com/watch?v=XtQMytORBmM&t=1979s
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    [ContextMenu("Increase score")]
    public void addScore()
    {
        playerScore = playerScore + 1;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

}
