using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int runningScore = 0;
    public int totalScore = 0;

    PlayerLevelController playerLevelController;
    EnemySpawner spawner;

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
        spawner = FindObjectOfType<EnemySpawner>();
    }

    private void ResetPlayerCurrentScore()
    {
        runningScore = 0;
        playerLevelController.UpdatePlayerLevel(runningScore);
        uiManager.Instance.UpdateScoreText(totalScore);
    }

    public void UpdateScore(int value)
    {
        totalScore += value; 
        runningScore += value;
        playerLevelController.UpdatePlayerLevel(runningScore);
        uiManager.Instance.UpdateScoreText(totalScore); 
    }
}
