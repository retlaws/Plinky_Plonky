using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backstop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Projectile>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
