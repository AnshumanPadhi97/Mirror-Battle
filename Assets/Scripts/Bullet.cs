using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public int dir;

    public float blastRadius;
    public float Blastdamage;
    // Use this for initialization
    void Start()
    {
        rb.velocity = dir * transform.right * speed;
        if (dir == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player")
        {
            PlayerHealth ph = hitInfo.gameObject.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.TakeDamage(damage);

                Instantiate(impactEffect, transform.position, transform.rotation);
                AreaDamageEnemies(transform.position, blastRadius, Blastdamage);
                Destroy(gameObject);
            }
        }
        else if (hitInfo.gameObject.tag == "Bomb" || hitInfo.gameObject.tag == "Obs")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            AreaDamageEnemies(transform.position, blastRadius, Blastdamage);
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.tag == "Ground" && SceneManager.GetActiveScene().buildIndex < 7)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            AreaDamageEnemies(transform.position, blastRadius, Blastdamage);
            Destroy(gameObject);
        }
    }

    void AreaDamageEnemies(Vector3 location, float radius, float damage)
    {
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(location, radius);
        foreach (Collider2D col in objectsInRange)
        {
            PlayerHealth ph = col.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                // linear falloff of effect
                float proximity = (location - ph.transform.position).magnitude;
                float effect = 1 - (proximity / radius);
                
                ph.TakeDamage(damage * effect);
            }
        }
    }
    
}

