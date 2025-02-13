using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager UIManager;
    public int playerHealth;
    private int playerHealthMax;


    private void Awake()
    {
        UIManager = FindObjectOfType<UIManager>().GetComponent<UIManager>();
    }

    public void TakePlayerDamage()
    {
        playerHealth--;
        if (playerHealth <= 0 )
        {
            GameOver();
        }
        UIManager.TakePlayerDamage();
    }
    public void UpdatePlayerMaxHealth(int amount)
    {
        playerHealthMax += amount;
        playerHealth = playerHealthMax;
    }
    public void GameOver()
    {
        print("Game Over!");
        //UI popup and scene reset imo
    }
}
