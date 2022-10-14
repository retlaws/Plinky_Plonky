using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int enemyScoreValue = 1;
    [SerializeField] int enemyHealth = 2;
    [SerializeField] float rateOfFire = 2f;


    [Header("Movement")]
    [Range(-10f, 10f)]
    [SerializeField] float movementSpeedXAxis = 4f;
    [Range(0f, 10f)]
    [SerializeField] float movementSpeedYAxis = 4f;

    [Header("Death Stuff")]
    [SerializeField] GameObject explosion;

    ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 move = new Vector2(movementSpeedXAxis * Time.deltaTime, movementSpeedYAxis * -1 * Time.deltaTime);
        transform.Translate(move,Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>() != null)
        {
            Destroy(gameObject);
        }

        if(collision.GetComponent<Projectile>() != null)
        {
            scoreManager.UpdateScore(enemyScoreValue);
            enemyHealth--; 
            if(enemyHealth == 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject); // should just move it to a pool at this stage
            }
        }

    }
}
