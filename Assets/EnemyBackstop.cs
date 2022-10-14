using UnityEngine;

public class EnemyBackstop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
