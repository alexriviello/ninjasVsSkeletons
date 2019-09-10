using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    [SerializeField] int health = 100;
    [SerializeField] GameObject deathFVX;
    [SerializeField] float deathDuration = 1f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.7f;

    float currentSpeed = 1f;

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime); //move the character to the left, make frame rate independent

    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Projectile projectile = other.gameObject.GetComponent<Projectile>(); // find out the damage component of whatever hit us
        if (!projectile) { return; }
        DoDamage(projectile);
    }

    private void DoDamage(Projectile projectile)
    {
        health -= projectile.GetDamage(); //subtract damage from health
        projectile.Hit(); //destroys player projectile
        if (health <= 0)    //if your health drops below zero
        {
            Die();

        }
    }

    private void Die()
    {
        TriggerDeathVFX();
        Destroy(gameObject);    //bye bye

    }

    private void TriggerDeathVFX()
    {
        if(!deathFVX) { return; }

            GameObject death = Instantiate(deathFVX, transform.position, transform.rotation); //make an explosion
            Destroy(death, deathDuration); //explode the explosion
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume); //sound the explosion
    }
}
