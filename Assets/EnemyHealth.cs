using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 20;
    int currentHealth;
    public Sprite deadSprite;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<SpriteRenderer>().sprite = deadSprite;


        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
