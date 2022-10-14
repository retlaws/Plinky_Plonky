using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        Instance = this; 
        DontDestroyOnLoad(this);
    }

    public void StartNewGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {

    }

    public void GameOver()
    {
        Time.timeScale = 0;
        uiManager.Instance.GameOver();
        FindObjectOfType<PlayerController>().DisableControls();
    }

}
