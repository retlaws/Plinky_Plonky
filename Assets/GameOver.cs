using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ReloadLevel()
    {
        gameManager.ReloadLevel();  
    }

    public void QuitGame()
    {
        gameManager.QuitGame();
    }
}
