using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to hold health, stamina and mana values and create an instance.

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public float currentHealth = 100;
    public float maxHealth = 100;
    public static float currentStamina = 100;
    public static float maxStamina = 100;
    public float currentMana = 100;
    public float maxMana = 100;

    public GameObject deathPanel;
    public GameObject inventory;
    public GameObject character;
    public GameObject consumable;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        OnDeath();
        ToggleBlockouts();
    }
    //function to toggle death screen on UI
    private void OnDeath()
    {
        if (currentHealth <= 0)
        {
            deathPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } 
    }
    //function to toggle UI blockouts
    private void ToggleBlockouts()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(!inventory.activeSelf);
            consumable.SetActive(!consumable.activeSelf);
            character.SetActive(!character.activeSelf);
        }
    }
}
