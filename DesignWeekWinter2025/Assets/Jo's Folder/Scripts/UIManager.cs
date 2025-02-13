using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject characterUIRef;
    public Transform characterUIPanel;
    private List<Character> characters;
    private List<Slider> sliders;

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

    public void SpawnCharacterUI(Character character)
    {
        GameObject newCharUI = Instantiate(characterUIRef, characterUIPanel);
        //sliders.Add(newCharUI.GetComponent<Slider>());
        //characters.Add(character);
        //Debug.Log(sliders.ToString());
    }
}
