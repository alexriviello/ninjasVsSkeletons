using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterDefender : MonoBehaviour
{

    [SerializeField] GameObject projectile, gun;

    public void ShootProjectile()
    {
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
        return;
    }
}
