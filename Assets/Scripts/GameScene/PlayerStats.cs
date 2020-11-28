using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// player script to handle displaying value changes or respawning player.

public class PlayerStats : MonoBehaviour
{
    public Image healthBar;
    public Image staminaBar;
    public Image manaBar;

    public GameObject deathScreen;
    public AudioSource respawnSound;
    public Transform player;
    public Transform spawnPoint;

    void Update()
    {
        HealthChange();
        StaminaChange();
        ManaChange();
    }
    // function mapped to UI to display health change
    void HealthChange()
    {
        float amount = Mathf.Clamp01(GameManager.instance.currentHealth / GameManager.instance.maxHealth);
        healthBar.fillAmount = amount;
    }
    // function mapped to UI to display stamina change
    void StaminaChange()
    {
        float amount = Mathf.Clamp01(GameManager.currentStamina / GameManager.maxStamina);
        staminaBar.fillAmount = amount;
    }
    // function mapped to UI to display mana change
    void ManaChange()
    {
        float amount = Mathf.Clamp01(GameManager.instance.currentMana / GameManager.instance.maxMana);
        manaBar.fillAmount = amount;
    }
    // respawn function to update player transform to spawnpoint
    // call physics engine to update transforms
    // reset player health, player respawn sound and toggle off death screen
    // lock cursor and start game time
    public void Respawn()
    {
        player.transform.position = spawnPoint.transform.position;
        Physics.SyncTransforms();
        GameManager.instance.currentHealth = 100;
        respawnSound.Play();
        deathScreen.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
    // temp damaging dealing function 
    public void DealDamage(float damage)
    {
        GameManager.instance.currentHealth -= damage;
    }
    // temp mana draining function
    public void UseMana(float mana)
    {
        GameManager.instance.currentMana -= mana;
    }
    // temp buttons on GUI to damage or drain mana.
    public void OnGUI()
    {
        if (GUI.Button(new Rect(220, 20, 120, 20), "Damage Player" + GameManager.instance.currentHealth)) // temp damage button
        {
            DealDamage(25f);
        }

        if (GUI.Button(new Rect(360, 20, 120, 20), "Drain Mana" + GameManager.instance.currentMana)) // temp Mana button
        {
            UseMana(25f);
        }
    }
}
