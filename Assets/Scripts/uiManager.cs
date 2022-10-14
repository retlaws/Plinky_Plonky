using TMPro;
using UnityEngine;

public class uiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI playerLevelText;
    [SerializeField] TextMeshProUGUI numberOfLivesText;
    [SerializeField] GameObject gameOverObject;
    [SerializeField] TextMeshProUGUI gameOverText; 

    public static uiManager Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score; 
    }

    public void UpdatePlayerLevelText(int Level)
    {
        playerLevelText.text = "Level: " + Level;
    }

    public void UpdatePlayerLifeText(int numberOfLives)
    {
        numberOfLivesText.text = "Number of Lives: " + numberOfLives;
    }

    public void GameOver()
    {
        gameOverObject.SetActive(true);
        gameOverText.text = "SCORE: " + FindObjectOfType<ScoreManager>().totalScore + "\n" + "GAME OVER";

    }
}
