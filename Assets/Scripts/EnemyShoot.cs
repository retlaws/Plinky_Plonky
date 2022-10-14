using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] float rateOfFire = 2f;
    [SerializeField] GameObject shotPrefab;
    [SerializeField] Transform shotStart;
    [SerializeField] float shotSpeed = 1f;

    bool ableToShoot = false;


    Transform player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<backstop>() != null)
        {
            ableToShoot=true;
        }
    }

    float timer = 0; 

    void Update()
    {
        if (ableToShoot)
        {
            timer += Time.deltaTime;

            float speed = 5 / rateOfFire; 

            if(timer > speed)
            {
                timer = 0; 
                Fire();
            }
        }
    }

    private void Fire()
    {
        Vector2 shotDirection = player.position - transform.position; 
        GameObject shot = Instantiate(shotPrefab, shotStart.position, Quaternion.identity);
        shot.GetComponent<Rigidbody2D>().AddForce(shotDirection * shotSpeed, ForceMode2D.Impulse);
    }
}
