using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponsController : MonoBehaviour
{
    [SerializeField] List<Weapon> weapons;
    
    Weapon currentWeapon;

    private void Awake()
    {
        currentWeapon = weapons[0];

    }

    public void ChangeWeapon(int playerLevel)
    {
        currentWeapon = weapons[playerLevel - 1];
    }

    public void Fire()
    {
        currentWeapon.Fire();
    }

    public void OnFireHoldStart(InputAction.CallbackContext context)
    {
        StartCoroutine(ContinuousFiring());
    }

    public void OnFireHoldPerformed(InputAction.CallbackContext context)
    {
        StopAllCoroutines();
    }

    IEnumerator ContinuousFiring()
    {
        float num = 0;

        while (true)
        {
            num += currentWeapon.fireRate * 10 * Time.deltaTime; //TODO 10 is a magic number need to check this

            if(num > 10) // this is an arbitrary number
            {
                num = 0;
                Fire();
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
