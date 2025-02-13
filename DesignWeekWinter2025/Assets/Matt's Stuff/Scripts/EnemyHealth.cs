using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject hitVFX;
    public int maxHealth;
    private Transform vfxSpawnPoint;
    private LayerMask playerLayer;
    private int currentHealth;

    private void Awake()
    {
        vfxSpawnPoint = transform.GetChild(0).transform;
        playerLayer = LayerMask.GetMask("Player");
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageTaken)
    {
        Instantiate(hitVFX, vfxSpawnPoint);
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
