using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject characterUIRef;
    public Transform characterUIPanel;
    public GameObject[] playerHearts;
    public GameObject gameOverPanel;
    private int characterCount;


    //yknow what, game comes first. Scrapping this for now
    //I think my problem is with Lists. I'd ask some friends for help, but the school's closed.
    //private List<Character> characters;
    //private List<Slider> sliders;

    //private void Update()
    //{
    //    Debug.Log($"{characters[0].name}");
    //    UpdateSliders();
    //}

    //public void UpdateSliders()
    //{
    //    print($"Running update sliders, sliders {sliders.Count}");
    //    int i = 0;
    //    foreach (Slider currentSlider in sliders)
    //    {
    //        currentSlider.value = 1/Time.time - 1/characters[i].attackTimer;
    //        print($"Current slider value: {currentSlider.value}");
    //        i++;
    //    }
    //}

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        characterCount = 0;
    }

    public void SpawnCharacterUI(Character character)
    {
        GameObject newCharUI = Instantiate(characterUIRef, characterUIPanel);
        characterCount++;
        gameManager.AddPlayerToCamera(character);
            //fuck it we'll do it in the UI manager IDGAF at this point LOL
        if (characterCount < 2)
        {
            gameManager.UpdatePlayerMaxHealth(3);
            for (int i = 0; i < playerHearts.Length-1; i++)
            {
                playerHearts[i].gameObject.SetActive(true);
            }
        } else
        {
            playerHearts[3].gameObject.SetActive(true);
            gameManager.UpdatePlayerMaxHealth(1);
        }

        //sliders.Add(newCharUI.GetComponent<Slider>());
        //characters.Add(character);
    }

    public void TakePlayerDamage()
    {
        playerHearts[gameManager.playerHealth].gameObject.SetActive(false);
        //remove a heart
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
