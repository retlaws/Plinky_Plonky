using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] int numberOfLives = 3;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>() != null)
        {
            numberOfLives--;
            if(numberOfLives <= 0)
            {
                GameManager.Instance.GameOver();
            }
            else
            {
                uiManager.Instance.UpdatePlayerLifeText(numberOfLives);
            }
        }
    }

    
}
