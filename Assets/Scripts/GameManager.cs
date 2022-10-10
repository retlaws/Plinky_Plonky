using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        uiManager.Instance.GameOver();
        FindObjectOfType<PlayerController>().DisableControls();
    }

}
