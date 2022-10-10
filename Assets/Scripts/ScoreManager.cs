using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int currentScore = 0;
    [SerializeField] int totalScore = 0;

    PlayerLevelController playerLevelController;

    public static ScoreManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    private void Start()
    {
        playerLevelController = FindObjectOfType<PlayerLevelController>();
    }

    private void ResetPlayerCurrentScore()
    {
        currentScore = 0;
        playerLevelController.UpdatePlayerLevel(currentScore);
        uiManager.Instance.UpdateScoreText(totalScore);
    }

    public void UpdateScore(int value)
    {
        totalScore += value; 
        currentScore += value;
        playerLevelController.UpdatePlayerLevel(currentScore);
        uiManager.Instance.UpdateScoreText(totalScore); 
    }
}
