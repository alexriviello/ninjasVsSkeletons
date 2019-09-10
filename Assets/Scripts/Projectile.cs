using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] int damage = 100;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //moves the projectile to the right at the given speed
    }

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
