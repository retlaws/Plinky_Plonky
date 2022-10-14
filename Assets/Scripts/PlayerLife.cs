using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] int numberOfLives = 3;
    [SerializeField] GameObject smokeFXPrefab;
    [SerializeField] AudioSource lifePickup;


    private void Start()
    {
        uiManager.Instance.UpdatePlayerLifeText(numberOfLives);
    }

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
                Instantiate(smokeFXPrefab, transform.position , Quaternion.identity, transform);
                uiManager.Instance.UpdatePlayerLifeText(numberOfLives);
            }
        }
    }

    public void AddLife()
    {
        numberOfLives++;
        uiManager.Instance.UpdatePlayerLifeText(numberOfLives);
        lifePickup.Play();
    }
    
}
