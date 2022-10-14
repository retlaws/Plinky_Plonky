using UnityEngine;

public class Projectile : MonoBehaviour
{
    float timer = 0; 

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 3)
        {
            Destroy(gameObject);
        }
    }
}
