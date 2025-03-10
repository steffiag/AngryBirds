using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // public EnemyPool enemyPool;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("enemy script is working");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemyDeath() 
    {
        // Add points to score/pubsub stuff
        Debug.Log("BLEH IM DED");
        StatsManager.Instance.EnemyKilled();
        gameObject.SetActive(false);
        EnemyPool.Instance.ReturnObject(this);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision woohoo");
        if (collision.gameObject.CompareTag("Block"))
        {
            HitByBlock(collision);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            EnemyDeath();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            EnemyDeath();
        }
    }

    void HitByBlock(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0); // Get the first contact point
        Vector3 contactPoint = contact.point; // Contact position
        Vector3 enemyPosition = transform.position; // Enemy's center position

        Vector3 hitDirection = contactPoint - enemyPosition; // Direction from enemy to block

        // Ignore bottom hits (hitDirection.y < 0)
        if (hitDirection.y >= 0)
        {
            Debug.Log("Enemy hit from left, right, or top!");
            EnemyDeath(); // Call function to handle the hit
        }
    }
}
