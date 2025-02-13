using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Character[] characters = FindObjectsOfType<Character>();
        foreach (Character character in characters)
        {
            Destroy(character.gameObject);
        }
        UIManager.GameOver();
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BackToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
