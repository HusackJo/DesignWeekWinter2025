using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    private LayerMask playerLayer;
    private int currentHealth;

    private void Awake()
    {
        playerLayer = LayerMask.GetMask("Player");
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
        if (currentHealth < 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            Character player = collision.gameObject.GetComponent<Character>();
            player.gameManager.TakePlayerDamage();
        }
    }
}
