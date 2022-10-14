using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : MonoBehaviour
{
    [Header("Movement")]
    [Range(-10f, 10f)]
    [SerializeField] float movementSpeedXAxis = 4f;
    [Range(0f, 10f)]
    [SerializeField] float movementSpeedYAxis = 4f;


    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 move = new Vector2(movementSpeedXAxis * Time.deltaTime, movementSpeedYAxis * -1 * Time.deltaTime);
        transform.Translate(move, Space.Self);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("collided");
        PlayerLife playerLife = collision.GetComponent<PlayerLife>();
        if (playerLife != null)
        {
            playerLife.AddLife();
            Destroy(gameObject);
        }
    }
}
