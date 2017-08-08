using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health = 300f;
    public float speed = 10.0f;
    public float padding = 1f;
    public GameObject projectile;
    public float projectileSpeed = 5f;
    public float firingRate = 0.1f;
    public AudioClip FireSound;
    public GameObject Explosion, Explosion_Hit;
    public AudioClip DeathSound;

    private ScoreKeeper scoreKeeper;

    float xmin = -5f;
    float ymin = -5f;
    float xmax = 5f;
    float ymax = 5f;

    private void Start()
    {
        float cameraDistance = transform.position.z - Camera.main.transform.position.z;
        Vector3 topleft = Camera.main.ViewportToWorldPoint(new Vector3(0,1,cameraDistance));  //this takes relative values. so 0.5 if the mouse is in the middle
        Vector3 bottomright = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, cameraDistance));
        xmin = topleft.x + padding; xmax = bottomright.x - padding;
        ymin = bottomright.y + padding;  ymax = topleft.y - padding;
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            InvokeRepeating("Fire", 0.00001f, firingRate);
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            CancelInvoke("Fire");
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        float newY = Mathf.Clamp(transform.position.y, ymin, ymax);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    private void Fire()
    {
        GameObject beam = Instantiate(projectile, transform.position , Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(FireSound, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missile = collider.GetComponent<Projectile>();
        if (missile)
        {
            Instantiate(Explosion_Hit, transform.position, Quaternion.identity);
            health -= missile.damage;
            if (health <= 0)
            {
                Die();
            }
        }
        missile.Hit();
    }

    private void Die()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(DeathSound, transform.position);
        Destroy(gameObject);
        LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelManager.LoadLevel("Lose");
    }
}
