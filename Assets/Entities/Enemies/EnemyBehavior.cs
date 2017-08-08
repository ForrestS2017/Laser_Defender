using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    public GameObject projectile;
    public float projectileSpeed = 10f;
    public float fireEveryRate = 1f;
    private float fireRate = .1f;
    public float health = 1000;
    public GameObject Explosion, Explosion_Hit;
    public int scoreValue = 150;
    public AudioClip FireSound;
    public AudioClip DeathSound;

    private float lastFireTime = 0f;
    private ScoreKeeper scoreKeeper;

    private void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            Instantiate(Explosion_Hit, transform.position, Quaternion.identity);
            health -= missile.GetDamage();
            if(health <= 0)
            {
                Die();
            }
            missile.Hit();

        }
    }

    private void Die()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        scoreKeeper.UpdateScore(scoreValue);
        AudioSource.PlayClipAtPoint(DeathSound, transform.position);
        Destroy(gameObject);
    }

    private void Update()
    {
        float probability = Time.deltaTime / fireEveryRate;
        if(UnityEngine.Random.value < probability)
        {
            if (Time.time - lastFireTime >= fireRate)
            {
                Fire();
            }
        }

    }

    private void Fire()
    {
        GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -projectileSpeed, 0f);
        AudioSource.PlayClipAtPoint(FireSound, transform.position);
        lastFireTime = Time.time;
    }
}
