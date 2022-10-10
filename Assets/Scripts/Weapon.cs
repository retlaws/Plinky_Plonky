using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 2f;
    [SerializeField] float speedOfProjectile = 10f;

    [Header("Projectile Starts")]
    [SerializeField] Transform[] transforms;
    [SerializeField] GameObject shotPrefab;
    [SerializeField] Transform player;
    public void Fire()
    {
        for (int i = 0; i < transforms.Length; i++)
        {
            Vector2 shotDirection = transforms[i].position - player.position;
            GameObject shot = Instantiate(shotPrefab, transforms[i].position, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().AddForce(shotDirection * speedOfProjectile, ForceMode2D.Impulse);
        }
    }

}
